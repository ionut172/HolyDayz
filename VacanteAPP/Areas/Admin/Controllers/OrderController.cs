using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vacante.DataAccess.Repository;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.Utility;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;
using OrderHeader = VacanteAPP.Models.OrderHeader;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacanteAPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (User.IsInRole(SD.Role_User_Admin))
            {
                return View("Index");
            }
            else
            {
                return View("IndexUser");
            }


        }


        public IActionResult Details(int? ID)
        {
            OrderVM orderVM = new()
            {

                orderHeader = _unitOfWork.orderHeaderRepository.Get(u => u.ID == ID, includeProprieties: "ApplicationUser"),
                orderDetails = _unitOfWork.detailsOrderRepository.GetAllLinq(u => u.OrderHeaderID == ID, includeProprieties: "CountryName")

            };
            orderVM.OrderStatusList = new List<SelectListItem>
    {
        new SelectListItem { Value = SD.StatusPending, Text = "In asteptare" },
        new SelectListItem { Value = SD.StatusApproved, Text = "Acceptata" },
        new SelectListItem { Value = SD.StatusInProcess, Text = "Se proceseaza comanda" },
        new SelectListItem { Value = SD.StatusShipped, Text = "Livrata" },
        new SelectListItem { Value = SD.StatusCancelled, Text = "Anulata" },
        new SelectListItem { Value = SD.StatusRefunded, Text = "Rambursata" }
    };


            return View(orderVM);
        }
        [HttpPost, ActionName("Details")]
        public IActionResult DetailsPOST(OrderHeader orderHeader)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.orderHeaderRepository.Update(orderHeader);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();

        }

        #region APICalls
        [HttpGet]
        public IActionResult GetAll()

        {
            IEnumerable<OrderHeader> orderHeaders;
            if (User.IsInRole(SD.Role_User_Admin) || User.IsInRole(SD.Role_User_Employee))
            {
                orderHeaders = _unitOfWork.orderHeaderRepository.GetAll(includeProprieties: "ApplicationUser").ToList();

                return Json(new { data = orderHeaders });
            }
            else
            {
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                orderHeaders = _unitOfWork.orderHeaderRepository.GetAllLinq(u => u.ApplicationUserId == userId, includeProprieties: "ApplcationUserId");
                return Json(new { data = orderHeaders });
            }
            return View();

        }
        #endregion
    }
}

