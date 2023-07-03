using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "VacanteStandard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 1,
                column: "CountryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 2,
                column: "CountryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 3,
                column: "CountryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 4,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 5,
                column: "CountryId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_VacanteStandard_CountryId",
                table: "VacanteStandard",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacanteStandard_Countries_CountryId",
                table: "VacanteStandard",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacanteStandard_Countries_CountryId",
                table: "VacanteStandard");

            migrationBuilder.DropIndex(
                name: "IX_VacanteStandard_CountryId",
                table: "VacanteStandard");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "VacanteStandard");
        }
    }
}
