using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LastShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_VacanteStandard_VacanteStandardVacantaId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "shoppingCarts");

            migrationBuilder.RenameColumn(
                name: "VacanteStandardVacantaId",
                table: "shoppingCarts",
                newName: "VacantaShopId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_VacanteStandardVacantaId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_VacantaShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_VacanteStandard_VacantaShopId",
                table: "shoppingCarts",
                column: "VacantaShopId",
                principalTable: "VacanteStandard",
                principalColumn: "VacantaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_VacanteStandard_VacantaShopId",
                table: "shoppingCarts");

            migrationBuilder.RenameColumn(
                name: "VacantaShopId",
                table: "shoppingCarts",
                newName: "VacanteStandardVacantaId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_VacantaShopId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_VacanteStandardVacantaId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_VacanteStandard_VacanteStandardVacantaId",
                table: "shoppingCarts",
                column: "VacanteStandardVacantaId",
                principalTable: "VacanteStandard",
                principalColumn: "VacantaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
