using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descriere",
                table: "LastMinute",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VacanteStandard",
                columns: table => new
                {
                    VacantaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameLastMinute = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    LastMinuteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacanteStandard", x => x.VacantaId);
                });

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "VacanteStandard",
                columns: new[] { "VacantaId", "Descriere", "DisplayOrder", "LastMinuteDate", "NameLastMinute", "Oras", "Pret" },
                values: new object[,]
                {
                    { 1, "descriere", 1, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), "5 zile in Malaga", "Malaga", 500m },
                    { 2, "descriere", 2, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), "Viziteaaza Casa Poporului", "Bucuresti", 300m },
                    { 3, "descriere", 3, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), "Piramidele Lumii", "Cairo", 1200m },
                    { 4, "descriere", 4, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), "Roma Antica", "Roma", 350m },
                    { 5, "descriere", 5, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), "Berlinul modern", "Berlin", 1500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacanteStandard");

            migrationBuilder.AlterColumn<string>(
                name: "Descriere",
                table: "LastMinute",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
