using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VacanteAPP_Razor.Data;
using VacanteAPP_Razor.Models;

namespace VacanteAPP_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public Category CategoryOne { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            this._db = db;
        }
        public void OnGet(int? CategoryId)
        {
            if (CategoryId != null && CategoryId != 0)
            {
                CategoryOne = _db.Categories.Find(CategoryId);
            }
        }
        public IActionResult OnPost()
        {
            _db.Categories.Update(CategoryOne);
            _db.SaveChanges();
            TempData["sucess"] = "Date editate cu succes";
            return RedirectToPage("Index");
        }
    }
}
