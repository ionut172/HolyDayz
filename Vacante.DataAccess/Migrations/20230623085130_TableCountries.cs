using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TableCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Italia" },
                    { 2, "Franta" },
                    { 3, "Romania" },
                    { 4, "Egipt" },
                    { 5, "Germania" },
                    { 6, "Spania" }
                });

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 2,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 3,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 4,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 5,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 2,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 3,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 4,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 5,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
