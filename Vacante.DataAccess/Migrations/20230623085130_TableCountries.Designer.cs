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
    [Migration("20230623085130_TableCountries")]
    partial class TableCountries
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            LastMinuteDate = new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Oferta Barcelona",
                            Oras = "Barcelona",
                            Pret = 500m
                        });
                });

            modelBuilder.Entity("VacanteAPP.Models.VacanteStandard", b =>
                {
                    b.Property<int>("VacantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacantaId"));

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

                    b.HasKey("VacantaId");

                    b.ToTable("VacanteStandard");

                    b.HasData(
                        new
                        {
                            VacantaId = 1,
                            Descriere = "descriere",
                            DisplayOrder = 1,
                            LastMinuteDate = new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "5 zile in Malaga",
                            Oras = "Malaga",
                            Pret = 500m
                        },
                        new
                        {
                            VacantaId = 2,
                            Descriere = "descriere",
                            DisplayOrder = 2,
                            LastMinuteDate = new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Viziteaaza Casa Poporului",
                            Oras = "Bucuresti",
                            Pret = 300m
                        },
                        new
                        {
                            VacantaId = 3,
                            Descriere = "descriere",
                            DisplayOrder = 3,
                            LastMinuteDate = new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Piramidele Lumii",
                            Oras = "Cairo",
                            Pret = 1200m
                        },
                        new
                        {
                            VacantaId = 4,
                            Descriere = "descriere",
                            DisplayOrder = 4,
                            LastMinuteDate = new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Roma Antica",
                            Oras = "Roma",
                            Pret = 350m
                        },
                        new
                        {
                            VacantaId = 5,
                            Descriere = "descriere",
                            DisplayOrder = 5,
                            LastMinuteDate = new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            NameLastMinute = "Berlinul modern",
                            Oras = "Berlin",
                            Pret = 1500m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
