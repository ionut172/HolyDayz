using System;
using Microsoft.EntityFrameworkCore;
namespace VacanteAPP.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LastMinute> LastMinute { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Last Minute", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Early Sales", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Oferte", DisplayOrder = 3 });

            modelBuilder.Entity<LastMinute>().HasData(
                new LastMinute { Descriere = "text", DisplayOrder = 1, LastMinuteDate = DateTime.Today, LastMinuteId = 1, NameLastMinute = "Oferta Barcelona", Oras = "Barcelona", Pret = 500 }
                );

        }
    }
}

