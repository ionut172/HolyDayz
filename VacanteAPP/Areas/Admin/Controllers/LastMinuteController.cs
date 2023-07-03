using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using VacanteAPP.Models;
namespace VacanteAPP.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = Vacante.Utility.SD.Role_User_Admin)]
public class LastMinuteController : Controller
{

    private readonly IUnitOfWork _unitOfWork;
    public LastMinuteController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<LastMinute> LastMinuteList = _unitOfWork.lastMinute.GetAll().ToList();
        return View(LastMinuteList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ActionName("Create")]
    public IActionResult CreatePOST(LastMinute obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.lastMinute.Add(obj);
            _unitOfWork.Save();
            TempData["sucess"] = "Vacanta Last Minute realizata cu success";

        }
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int? LastMinuteId)
    {

        LastMinute vacantaEdit = _unitOfWork.lastMinute.Get(u => u.LastMinuteId == LastMinuteId);

        return View(vacantaEdit);


    }
    [HttpPost, ActionName("Edit")]
    public IActionResult EditPOST(LastMinute obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.lastMinute.Update(obj);
            _unitOfWork.Save();
            TempData["sucess"] = "Vacanta Last Minute editata cu success";
            return RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult Delete(int? LastMinuteId)
    {
        if (LastMinuteId == 0)
        {
            return NotFound();
        }
        if (LastMinuteId != 0 || LastMinuteId != null)
        {
            LastMinute obiect = _unitOfWork.lastMinute.Get(u => u.LastMinuteId == LastMinuteId);
            return View(obiect);
        }
        return View();
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int LastMinuteId)
    {
        LastMinute vacanta = _unitOfWork.lastMinute.Get(u => u.LastMinuteId == LastMinuteId);
        if (ModelState.IsValid)
        {
            _unitOfWork.lastMinute.Remove(vacanta);
            _unitOfWork.Save();
            TempData["sucess"] = "Vacanta Last Minute stearsa cu success";
            return RedirectToAction("Index");
        }
        return View();
    }
}

