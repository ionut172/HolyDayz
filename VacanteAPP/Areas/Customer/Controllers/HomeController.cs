using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vacante.DataAccess.Repository.IRepository;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace VacanteAPP.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        this._unitOfWork = unitOfWork;

    }

    public IActionResult Index()
    {
        var claimIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

        if (claim != null)
        {
            HttpContext.Session.SetInt32(Vacante.Utility.SD.SessionCart, _unitOfWork.ShoppingCart.GetAllLinq(u => u.ApplicationUserId == claim.Value, includeProprieties: "CountryName").Count());
        }
        List<VacanteStandard> vacanteStandards = _unitOfWork.VacanteStandard.GetAll(includeProprieties: "CountryName").ToList();
        IEnumerable<SelectListItem> listaOrase = _unitOfWork.countries.GetAll().Select(u => new SelectListItem
        {
            Text = u.CountryId.ToString(),
            Value = u.CountryName
        });

        VacanteStandardVM viewModel = new VacanteStandardVM
        {
            vacanteStandards = vacanteStandards,
            listaOrase = listaOrase
        };

        return View(viewModel);
    }
    public IActionResult Details(int VacantaId, VacanteStandardVM param)
    {
        ShoppingCart cart = new ShoppingCart();
        cart.Vacanta = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == VacantaId);
        cart.Count = 1;
        cart.VacantaShopId = VacantaId;
        VacanteStandard vacantaSingura = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == VacantaId);
        IEnumerable<SelectListItem> listItems = _unitOfWork.countries.GetAll().Select(u => new SelectListItem
        {
            Text = u.CountryName,
            Value = u.CountryId.ToString()
        });

        VacanteStandardVM vacanteStandardVM = new VacanteStandardVM
        {
            vacantaSingura = vacantaSingura,
            listaOrase = listItems
        };

        ViewData["CountryList"] = listItems;

        return View(cart);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Details(ShoppingCart shoppingCart, int VacantaId)
    {
        var claimIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.VacantaShopId == shoppingCart.VacantaShopId);
        if (cartFromDb != null)
        {
            cartFromDb.Count += shoppingCart.Count;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();
        }
        else
        {
            shoppingCart.ApplicationUserId = userId;
            _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();

        }


        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

