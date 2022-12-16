using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStateEnumToInquiry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("af7b72a4-6b47-4c68-9713-3ad75bbe0577"));

            migrationBuilder.AddColumn<byte>(
                name: "State",
                table: "Inquiries",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("6e529c96-799d-429d-8062-0a900d8b7492"), "pracownik.jeden01@gmail.com", "pracownik", "jeden" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("6e529c96-799d-429d-8062-0a900d8b7492"));

            migrationBuilder.DropColumn(
                name: "State",
                table: "Inquiries");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("af7b72a4-6b47-4c68-9713-3ad75bbe0577"), "pracownik.jeden01@gmail.com", "pracownik", "jeden" });
        }
    }
}
