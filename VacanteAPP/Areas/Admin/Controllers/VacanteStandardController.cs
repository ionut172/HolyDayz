using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VacanteAPP.Models;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository;
using Vacante.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using VacanteAPP.Models.ViewModels;
using VacanteStandard = VacanteAPP.Models.VacanteStandard;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacanteAPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Vacante.Utility.SD.Role_User_Admin)]
    public class VacanteStandardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VacanteStandardController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this._unitOfWork = unitOfWork;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
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


        public IActionResult Create()
        {
            IEnumerable<SelectListItem> listItems = _unitOfWork.countries.GetAll().Select(u => new SelectListItem
            {
                Text = u.CountryName,
                Value = u.CountryId.ToString()
            });
            VacanteStandardVM vacanteStandardVM = new VacanteStandardVM(new VacanteStandard(), listItems);




            return View(vacanteStandardVM);

        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(VacanteStandardVM vacanteStandardVM, IFormFile? URL)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;


                Guid guid = Guid.NewGuid(); // Generate a unique identifier
                string fileName = guid.ToString() + Path.GetExtension(URL.FileName);
                string imagePath = Path.Combine(wwwRootPath, @"images/vacanteStandard");
                if (!string.IsNullOrEmpty(vacanteStandardVM.vacanteStandard.URL))
                {
                    var oldImage = Path.Combine(wwwRootPath, vacanteStandardVM.vacanteStandard.URL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                };
                using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                {
                    URL.CopyTo(fileStream);
                }
                vacanteStandardVM.vacanteStandard.URL = @"\images\vacanteStandard\" + fileName;

                _unitOfWork.VacanteStandard.Add(vacanteStandardVM.vacanteStandard);
                _unitOfWork.Save();
                TempData["sucess"] = "Vacanta realizata cu success";
                return RedirectToAction("Index");


            }
            return View(vacanteStandardVM);






        }


        public IActionResult Edit(int VacantaId, VacanteStandardVM param)
        {



            VacanteStandard vacanteStandard = _unitOfWork.VacanteStandard.Get(u => u.VacantaId == VacantaId);
            IEnumerable<SelectListItem> listItems = _unitOfWork.countries.GetAll().Select(u => new SelectListItem
            {
                Text = u.CountryName,
                Value = u.CountryId.ToString()
            });

            VacanteStandardVM vacanteStandardVM = new VacanteStandardVM
            {
                vacanteStandard = vacanteStandard,
                listaOrase = listItems
            };

            ViewData["CountryList"] = listItems;

            return View(vacanteStandardVM);





        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(VacanteStandardVM obj, IFormFile? URL)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;



                Guid guid = Guid.NewGuid(); // Generate a unique identifier
                string fileName = guid.ToString() + Path.GetExtension(URL.FileName);
                string imagePath = Path.Combine(wwwRootPath, @"images/vacanteStandard");
                if (!string.IsNullOrEmpty(obj.vacanteStandard.URL))
                {
                    var oldImage = Path.Combine(wwwRootPath, obj.vacanteStandard.URL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                };
                using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                {
                    URL.CopyTo(fileStream);
                }
                obj.vacanteStandard.URL = @"\images\vacanteStandard\" + fileName;

                _unitOfWork.VacanteStandard.Update(obj.vacanteStandard);
                _unitOfWork.Save();
                TempData["sucess"] = "Vacanta modificata cu success";
                return RedirectToAction("Index");

            }
            return View("Index");

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
                TempData["sucess"] = "Vacanta stearsa cu success";
                return RedirectToAction("Index");
            }
            return View();
        }
        #region APICalls
        [HttpGet]
        public IActionResult GetAll()
        {
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
            return Json(new { data = viewModel.vacanteStandards });
        }
        #endregion
    }

}


