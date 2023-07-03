using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VacanteAPP.Models.ViewModels;

namespace VacanteAPP.Models
{
    public class VacanteStandard
    {
        [Key]
        public int VacantaId { get; set; }

        [Required]
        [DisplayName("Numele Vacantei")]
        [ValidateNever]
        [MaxLength(30, ErrorMessage = "Maximum de litere admise este 30")]
        public string NameLastMinute { get; set; }

        [Required]
        [DisplayName("Display Order")]
        [ValidateNever]
        [Range(1, 50, ErrorMessage = "Numarul de afisare trebuie sa fie intre 1-50")]
        public int DisplayOrder { get; set; }

        [Required]
        [DisplayName("Data Vacantei")]
        [DataType(DataType.Date)]
        [ValidateNever]
        public DateTime LastMinuteDate { get; set; }

        [Required]
        [DisplayName("Oraș")]
        [ValidateNever]

        public string Oras { get; set; }

        [Required]
        [DisplayName("Pret")]
        [ValidateNever]
        public decimal Pret { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Descrierea trebuia sa aiba maxim 200 caractere")]
        [ValidateNever]
        [DisplayName("Descriere")]
        public string Descriere { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        [ValidateNever]
        public Countries Countries { get; set; }

        [ValidateNever]
        public string URL { get; set; }
        public VacanteStandard()
        {
        }


    }
}

