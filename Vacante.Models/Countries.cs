using System;
using System.ComponentModel.DataAnnotations;

namespace VacanteAPP.Models
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Ai introdus mai mult de 20 de caractere")]
        public string CountryName { get; set; }
        public Countries()
        {
        }
    }
}

