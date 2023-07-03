﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vacante.DataAccess.Data;

#nullable disable

namespace Vacante.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230629091245_SessionId")]
    partial class SessionId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VacanteAPP.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            DisplayOrder = 1,
                            Name = "Last Minute"
                        },
                        new
                        {
                            CategoryId = 2,
                            DisplayOrder = 2,
                            Name = "Early Sales"
                        },
                        new
                        {
                            CategoryId = 3,
                            DisplayOrder = 3,
                            Name = "Oferte"
                        });
                });

            modelBuilder.Entity("VacanteAPP.Models.Countries", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Italia"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Franta"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Romania"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "Egipt"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "Germania"
                        },
                        new
                        {
                            CountryId = 6,
                            CountryName = "Spania"
                        });
                });

            modelBuilder.Entity("VacanteAPP.Models.LastMinute", b =>
                {
                    b.Property<int>("LastMinuteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LastMinuteId"));

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastMinuteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameLastMinute")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Oras")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LastMinuteId");

                    b.ToTable("LastMinute");

                    b.HasData(
                        new
                        {
                            LastMinuteId = 1,
                            Descriere = "text",
                            DisplayOrder = 1,
                            LastMinuteDate = new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Oferta Barcelona",
                            Oras = "Barcelona",
                            Pret = 500m
                        });
                });

            modelBuilder.Entity("VacanteAPP.Models.OrderDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderHeaderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VacantaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderHeaderID");

                    b.HasIndex("VacantaID");

                    b.ToTable("orderDetails");
                });

            modelBuilder.Entity("VacanteAPP.Models.OrderHeader", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("orderHeaders");
                });

            modelBuilder.Entity("VacanteAPP.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("VacantaShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("VacantaShopId");

                    b.ToTable("shoppingCarts");
                });

            modelBuilder.Entity("VacanteAPP.Models.VacanteStandard", b =>
                {
                    b.Property<int>("VacantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacantaId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastMinuteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameLastMinute")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Oras")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VacantaId");

                    b.HasIndex("CountryId");

                    b.ToTable("VacanteStandard");

                    b.HasData(
                        new
                        {
                            VacantaId = 1,
                            CountryId = 6,
                            Descriere = "descriere",
                            DisplayOrder = 1,
                            LastMinuteDate = new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "5 zile in Malaga",
                            Oras = "Malaga",
                            Pret = 500m,
                            URL = ""
                        },
                        new
                        {
                            VacantaId = 2,
                            CountryId = 3,
                            Descriere = "descriere",
                            DisplayOrder = 2,
                            LastMinuteDate = new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Viziteaaza Casa Poporului",
                            Oras = "Bucuresti",
                            Pret = 300m,
                            URL = ""
                        },
                        new
                        {
                            VacantaId = 3,
                            CountryId = 4,
                            Descriere = "descriere",
                            DisplayOrder = 3,
                            LastMinuteDate = new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Piramidele Lumii",
                            Oras = "Cairo",
                            Pret = 1200m,
                            URL = ""
                        },
                        new
                        {
                            VacantaId = 4,
                            CountryId = 1,
                            Descriere = "descriere",
                            DisplayOrder = 4,
                            LastMinuteDate = new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Roma Antica",
                            Oras = "Roma",
                            Pret = 350m,
                            URL = ""
                        },
                        new
                        {
                            VacantaId = 5,
                            CountryId = 5,
                            Descriere = "descriere",
                            DisplayOrder = 5,
                            LastMinuteDate = new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Berlinul modern",
                            Oras = "Berlin",
                            Pret = 1500m,
                            URL = ""
                        });
                });

            modelBuilder.Entity("VacanteAPP.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oras")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "concurrency_stamp",
                            Email = "john.doe@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                            NormalizedUserName = "JOHN.DOE",
                            PasswordHash = "<parola>",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "1234",
                            TwoFactorEnabled = false,
                            UserName = "john.doe",
                            Adresa = "123 Main St",
                            CodPostal = "12345",
                            Name = "John Doe",
                            Oras = "New York"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VacanteAPP.Models.OrderDetails", b =>
                {
                    b.HasOne("VacanteAPP.Models.OrderHeader", "OrderHeader")
                        .WithMany()
                        .HasForeignKey("OrderHeaderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacanteAPP.Models.VacanteStandard", "vacanteStandard")
                        .WithMany()
                        .HasForeignKey("VacantaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");

                    b.Navigation("vacanteStandard");
                });

            modelBuilder.Entity("VacanteAPP.Models.OrderHeader", b =>
                {
                    b.HasOne("VacanteAPP.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("VacanteAPP.Models.ShoppingCart", b =>
                {
                    b.HasOne("VacanteAPP.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacanteAPP.Models.VacanteStandard", "Vacanta")
                        .WithMany()
                        .HasForeignKey("VacantaShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Vacanta");
                });

            modelBuilder.Entity("VacanteAPP.Models.VacanteStandard", b =>
                {
                    b.HasOne("VacanteAPP.Models.Countries", "Countries")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
