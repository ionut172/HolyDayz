using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderHeaders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderHeaders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_orderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderID = table.Column<int>(type: "int", nullable: false),
                    VacantaID = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_orderDetails_VacanteStandard_VacantaID",
                        column: x => x.VacantaID,
                        principalTable: "VacanteStandard",
                        principalColumn: "VacantaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_orderHeaders_OrderHeaderID",
                        column: x => x.OrderHeaderID,
                        principalTable: "orderHeaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 2,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 3,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 4,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 5,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrderHeaderID",
                table: "orderDetails",
                column: "OrderHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_VacantaID",
                table: "orderDetails",
                column: "VacantaID");

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_ApplicationUserId",
                table: "orderHeaders",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "orderHeaders");

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 2,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 3,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 4,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 5,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
