using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VacanteAPP.Models.ViewModels
{
    public class VacanteStandardVM
    {
        [ValidateNever]
        public VacanteStandard vacanteStandard { get; set; }
        [ValidateNever]
        public VacanteStandard vacantaSingura { get; set; }
        [ValidateNever]
        public IEnumerable<VacanteStandard> vacanteStandards { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> listaOrase { get; set; }
        [ValidateNever]
        public Countries Countries { get; set; }

        public VacanteStandardVM(VacanteStandard v, IEnumerable<SelectListItem> lista)
        {
            this.vacanteStandard = v;
            this.listaOrase = lista;
        }

        public VacanteStandardVM(List<VacanteStandard> v, IEnumerable<SelectListItem> lista)
        {

        }


        public VacanteStandardVM()
        {

        }

        public static List<VacanteStandard> Lista()
        {
            List<VacanteStandard> vacanteList = new List<VacanteStandard>();
            vacanteList = vacanteList.OrderBy(u => u.DisplayOrder).ToList();

            return vacanteList;
        }



    }
}

