using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VacanteAPP.Models;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository;
using Vacante.DataAccess.Repository.IRepository;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacanteAPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VacanteStandardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VacanteStandardController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<VacanteAPP.Models.VacanteStandard> vacanteStandards = _unitOfWork.VacanteStandard.GetAll().ToList();
            return View(vacanteStandards);

        }

        public IActionResult Create()
        {

            return View();

        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(VacanteAPP.Models.VacanteStandard obj)
        {
            _unitOfWork.VacanteStandard.Add(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int VacantaId)
        {
            VacanteAPP.Models.VacanteStandard vacanta = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == VacantaId);
            return View(vacanta);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(VacanteAPP.Models.VacanteStandard obj)
        {

            _unitOfWork.VacanteStandard.Update(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int VacantaId)
        {
            VacanteAPP.Models.VacanteStandard obiectSters = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == VacantaId);
            return View(obiectSters);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteVacanta(VacanteAPP.Models.VacanteStandard obj)
        {
            if (obj != null)
            {
                _unitOfWork.VacanteStandard.Remove(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

