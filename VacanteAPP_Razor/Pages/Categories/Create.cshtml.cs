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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public Category CategoryOne { get; set; }
        public CreateModel(ApplicationDBContext db)
        {
            this._db = db;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(CategoryOne);
            _db.SaveChanges();
            TempData["sucess"] = "Date adaugate cu succes";
            return RedirectToPage("Index");
        }
    }
}
