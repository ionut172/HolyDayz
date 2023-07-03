using System;
using Microsoft.AspNetCore.Identity;

namespace VacanteAPP.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? Name { get; set; }
        public string? Adresa { get; set; }
        public string? Oras { get; set; }
        public string? CodPostal { get; set; }
        public ApplicationUser()
        {
        }
    }
}

