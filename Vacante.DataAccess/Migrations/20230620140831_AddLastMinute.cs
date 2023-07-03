using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLastMinute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LastMinute",
                columns: table => new
                {
                    LastMinuteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameLastMinute = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    LastMinuteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastMinute", x => x.LastMinuteId);
                });

            migrationBuilder.InsertData(
                table: "LastMinute",
                columns: new[] { "LastMinuteId", "Descriere", "DisplayOrder", "LastMinuteDate", "NameLastMinute", "Oras", "Pret" },
                values: new object[] { 1, "text", 1, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Local), "Oferta Barcelona", "Barcelona", 500m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastMinute");
        }
    }
}
