using System;
using VacanteAPP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace VacanteAPP.Models.ViewModels
{
    public class CountryVM
    {

        public Countries Countries { get; set; }
        public IEnumerable<SelectListItem> listaTari { get; set; }

        public CountryVM()
        {
        }
    }
}

