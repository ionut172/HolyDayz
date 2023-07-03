using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VacanteAPP.Models
{
    public class OrderHeader
    {
        [Key]
        public int ID { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentId { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string CodPostal { get; set; }
        [Required]
        public string Name { get; set; }
        public OrderHeader()
        {
        }
    }
}

