using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VacanteAPP.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Numele Categoriei")]
        [MaxLength(30, ErrorMessage = "Maximum de litere admise este 30")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1, 50, ErrorMessage = "Numarul de afisare trebuie sa fie intre 1-50")]
        public int DisplayOrder { get; set; }

        public Category()
        {


        }
    }
}

