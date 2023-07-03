using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Vacante.DataAccess.Migrations;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.Utility;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;
using ShoppingCart = VacanteAPP.Models.ShoppingCart;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacanteAPP.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public VacanteStandardVM VacanteStandardVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAllLinq(u => u.ApplicationUserId == userId, includeProprieties: "CountryName"),
                OrderHeader = new()
            };

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Vacanta = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == cart.VacantaShopId);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Vacanta.Pret * cart.Count);
            }
            return View(ShoppingCartVM);
        }



        public IActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                VacanteAPP.Models.ShoppingCart obiectSters = _unitOfWork.ShoppingCart.Get(u => u.Id == Id, tracked: true);
                _unitOfWork.ShoppingCart.Remove(obiectSters);
                HttpContext.Session.SetInt32(Vacante.Utility.SD.SessionCart, _unitOfWork.ShoppingCart.GetAllLinq(u => u.ApplicationUserId == obiectSters.ApplicationUserId, includeProprieties: "CountryName").Count() - 1);
                _unitOfWork.Save();

                TempData["sucess"] = "Element stears cu success";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAllLinq(u => u.ApplicationUserId == userId, includeProprieties: "CountryName"),
                OrderHeader = new()
            };
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.applicationUser.Get(u => u.Id == userId);
            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.Adresa = ShoppingCartVM.OrderHeader.ApplicationUser.Adresa;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.Oras;
            ShoppingCartVM.OrderHeader.CodPostal = ShoppingCartVM.OrderHeader.ApplicationUser.CodPostal;
            ShoppingCartVM.OrderHeader.Telefon = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Vacanta = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == cart.VacantaShopId);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Vacanta.Pret * cart.Count);
            }
            return View(ShoppingCartVM);
        }
        [HttpPost, ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAllLinq(u => u.ApplicationUserId == userId, includeProprieties: "CountryName");

            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;
            ShoppingCartVM.OrderHeader.PaymentStatus = SD.StatusPending;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;

            var domain = "https://localhost:7250/";

            _unitOfWork.orderHeaderRepository.Add(ShoppingCartVM.OrderHeader); // Add the order header to generate an ID
            _unitOfWork.Save();

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"Customer/Cart/OrderConfirmation/?id={ShoppingCartVM.OrderHeader.ID}", // Use the generated ID
                CancelUrl = domain + "Customer/Cart/Index",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Vacanta = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == cart.VacantaShopId);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Vacanta.Pret * cart.Count);

                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(cart.Vacanta.Pret * 100),
                        Currency = "RON",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = cart.Vacanta.NameLastMinute
                        }
                    },
                    Quantity = cart.Count
                };

                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                OrderDetails orderDetails = new()
                {
                    VacantaID = cart.VacantaShopId,
                    OrderHeaderID = ShoppingCartVM.OrderHeader.ID,
                    Pret = cart.Vacanta.Pret,
                    Count = cart.Count,
                };
                _unitOfWork.detailsOrderRepository.Add(orderDetails);
                _unitOfWork.Save();
            }
            _unitOfWork.orderHeaderRepository.UpdateStripePaymentId(ShoppingCartVM.OrderHeader.ID, session.Id, session.PaymentIntentId);

            _unitOfWork.Save();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult OrderConfirmation(int id)
        {
            OrderHeader orderHeader = _unitOfWork.orderHeaderRepository.Get(u => u.ID == id, includeProprieties: "CountryName");
            if (orderHeader.PaymentStatus != SD.StatusCancelled)
            {
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.orderHeaderRepository.UpdateStatus(orderHeader.ID, SD.StatusApproved, SD.StatusApproved);
                    HttpContext.Session.Clear();
                    _unitOfWork.Save();
                }
            }
            List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAllLinq(u => u.ApplicationUserId == orderHeader.ApplicationUserId, includeProprieties: "CountryName")
                .ToList();
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();
            return View(id);
        }
    }

}

