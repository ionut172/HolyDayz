using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VacanteAPP.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        [Required]
        public int OrderHeaderID { get; set; }
        [ForeignKey("OrderHeaderID")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        public int VacantaID { get; set; }
        [ForeignKey("VacantaID")]
        [ValidateNever]
        public VacanteStandard vacanteStandard { get; set; }
        public int Count { get; set; }
        public decimal Pret { get; set; }

    }
}

