using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VacanteAPP.Models;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository;
using Vacante.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Data;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacanteAPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Vacante.Utility.SD.Role_User_Admin)]
    public class CountriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountriesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<VacanteAPP.Models.Countries> countries = (List<Models.Countries>)_unitOfWork.countries.GetAll();
            return View(countries);

        }

        public IActionResult Create()
        {

            return View();

        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(VacanteAPP.Models.Countries obj)
        {
            _unitOfWork.countries.Add(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int CountryId)
        {
            VacanteAPP.Models.Countries tara = _unitOfWork.countries.Get(u => u.CountryId == CountryId);
            return View(tara);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(VacanteAPP.Models.Countries obj)
        {

            _unitOfWork.countries.Update(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int CountryId)
        {
            VacanteAPP.Models.Countries obiectSters = _unitOfWork.countries.Get(u => u.CountryId == CountryId);
            return View(obiectSters);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteVacanta(VacanteAPP.Models.Countries obj)
        {
            if (obj != null)
            {
                _unitOfWork.countries.Remove(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

