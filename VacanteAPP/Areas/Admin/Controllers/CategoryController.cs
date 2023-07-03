using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacante.DataAccess;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using VacanteAPP.Models;

namespace VacanteAPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Vacante.Utility.SD.Role_User_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<Category> listaCategorii;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            listaCategorii = _unitOfWork.Category.GetAll().ToList();
            return View(listaCategorii);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Numarul de afisare nu trebuie sa fie la fel ca numele");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("name", "TEST is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["sucess"] = "Categorie realizata cu success";
                return RedirectToAction("Index");
            }

            return View();
        }



        public IActionResult Edit(int? CategoryId)
        {
            if (CategoryId == 0 || CategoryId == null)
            {
                return NotFound();
            }


            Category obiect = _unitOfWork.Category.Get(u => u.CategoryId == CategoryId);
            if (obiect != null)
            {
                return View(obiect);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]

        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["sucess"] = "Categorie modificata cu success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? CategoryId)
        {

            if (CategoryId == null || CategoryId == 0)
            {
                return NotFound();
            }

            if (CategoryId == 0 || CategoryId == null)
            {
                return NotFound();
            }


            Category obiect = _unitOfWork.Category.Get(u => u.CategoryId == CategoryId);
            return View(obiect);

        }


        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? CategoryId)

        {
            Category obiect = _unitOfWork.Category.Get(u => u.CategoryId == CategoryId);

            _unitOfWork.Category.Remove(obiect);
            _unitOfWork.Save();
            TempData["sucess"] = "Categorie stearsa cu success";
            return RedirectToAction("Index");

        }


    }
}

