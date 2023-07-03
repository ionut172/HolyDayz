using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacante.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Discriminator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adresa", "CodPostal", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Oras", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3", 0, "123 Main St", "12345", "concurrency_stamp", "ApplicationUser", "john.doe@example.com", true, true, null, "John Doe", "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "New York", "<parola>", "1234567890", true, "1234", false, "john.doe" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LastMinute",
                keyColumn: "LastMinuteId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 1,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 2,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 3,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 4,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VacanteStandard",
                keyColumn: "VacantaId",
                keyValue: 5,
                column: "LastMinuteDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
