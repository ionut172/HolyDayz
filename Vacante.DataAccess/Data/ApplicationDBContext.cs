using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VacanteAPP.Models;
using Microsoft.AspNetCore.Identity;

namespace Vacante.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext() : base()
        {
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Vacante;User Id =sa; Password=Plesescu1;TrustServerCertificate=True");
            }

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<LastMinute> LastMinute { get; set; }
        public DbSet<VacanteStandard> VacanteStandard { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<OrderHeader> orderHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Last Minute", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Early Sales", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Oferte", DisplayOrder = 3 });

            modelBuilder.Entity<LastMinute>().HasData(
                new LastMinute { Descriere = "text", DisplayOrder = 1, LastMinuteDate = DateTime.Today, LastMinuteId = 1, NameLastMinute = "Oferta Barcelona", Oras = "Barcelona", Pret = 500 }
                );

            modelBuilder.Entity<VacanteStandard>().HasData(
                new VacanteStandard { Descriere = "descriere", DisplayOrder = 1, LastMinuteDate = DateTime.Today, VacantaId = 1, NameLastMinute = "5 zile in Malaga", Oras = "Malaga", Pret = 500, CountryId = 6, URL = "" },
                new VacanteStandard { Descriere = "descriere", DisplayOrder = 2, LastMinuteDate = DateTime.Today, VacantaId = 2, NameLastMinute = "Viziteaaza Casa Poporului", Oras = "Bucuresti", Pret = 300, CountryId = 3, URL = "" },
                new VacanteStandard { Descriere = "descriere", DisplayOrder = 3, LastMinuteDate = DateTime.Today, VacantaId = 3, NameLastMinute = "Piramidele Lumii", Oras = "Cairo", Pret = 1200, CountryId = 4, URL = "" },
                new VacanteStandard { Descriere = "descriere", DisplayOrder = 4, LastMinuteDate = DateTime.Today, VacantaId = 4, NameLastMinute = "Roma Antica", Oras = "Roma", Pret = 350, CountryId = 1, URL = "" },
                new VacanteStandard { Descriere = "descriere", DisplayOrder = 5, LastMinuteDate = DateTime.Today, VacantaId = 5, NameLastMinute = "Berlinul modern", Oras = "Berlin", Pret = 1500, CountryId = 5, URL = "" }
            );
            modelBuilder.Entity<Countries>().HasData(
                new Countries { CountryId = 1, CountryName = "Italia" },
                new Countries { CountryId = 2, CountryName = "Franta" },
                new Countries { CountryId = 3, CountryName = "Romania" },
                new Countries { CountryId = 4, CountryName = "Egipt" },
                new Countries { CountryId = 5, CountryName = "Germania" },
                new Countries { CountryId = 6, CountryName = "Spania" }

                );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "3", // Set the unique identifier for the user
                    UserName = "john.doe", // Set the username
                    NormalizedUserName = "JOHN.DOE", // Set the normalized username
                    Email = "john.doe@example.com", // Set the email address
                    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM", // Set the normalized email address
                    EmailConfirmed = true, // Set whether the email is confirmed or not
                    PasswordHash = "<parola>", // Set the hashed password
                    SecurityStamp = "1234", // Set the security stamp
                    ConcurrencyStamp = "concurrency_stamp", // Set the concurrency stamp
                    PhoneNumber = "1234567890", // Set the phone number
                    PhoneNumberConfirmed = true, // Set whether the phone number is confirmed or not
                    TwoFactorEnabled = false, // Set whether two-factor authentication is enabled or not
                    LockoutEnd = null, // Set the lockout end date/time
                    LockoutEnabled = true, // Set whether the lockout is enabled or not
                    AccessFailedCount = 0, // Set the access failed count
                    Adresa = "123 Main St", // Set the address
                    CodPostal = "12345", // Set the postal cod
                    Name = "John Doe", // Set the name
                    Oras = "New York", // Set the city

                }
                );

        }

    }
}

