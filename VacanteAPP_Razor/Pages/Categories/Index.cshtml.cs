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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDBContext db)
        {
            this._db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
