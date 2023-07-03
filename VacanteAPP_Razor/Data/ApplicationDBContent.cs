using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using VacanteAPP_Razor.Models;

namespace VacanteAPP_Razor.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Last Minute", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Early Sales", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Oferte", DisplayOrder = 3 });



        }
    }
}

