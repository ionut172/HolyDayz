using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SessionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OrderTotal",
                table: "orderHeaders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "orderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 2,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 3,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 4,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 5,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<double>(
                name: "OrderTotal",
                table: "orderHeaders",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
        }
    }
}
