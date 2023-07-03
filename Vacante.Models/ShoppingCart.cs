using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VacanteAPP.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int VacantaShopId { get; set; }
        [ForeignKey("VacantaShopId")]
        [ValidateNever]
        public VacanteStandard Vacanta { get; set; }
        [Range(1, 1000, ErrorMessage = "Maxim 1000 produse")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public decimal Pret { get; set; }


        public ShoppingCart()
        {
        }
    }
}

