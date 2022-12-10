using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInquiry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Employees_reviewerId",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Inquiries");

            migrationBuilder.RenameColumn(
                name: "reviewerId",
                table: "Inquiries",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Inquiries_reviewerId",
                table: "Inquiries",
                newName: "IX_Inquiries_ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Employees_ReviewerId",
                table: "Inquiries",
                column: "ReviewerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Employees_ReviewerId",
                table: "Inquiries");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Inquiries",
                newName: "reviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Inquiries_ReviewerId",
                table: "Inquiries",
                newName: "IX_Inquiries_reviewerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Inquiries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Employees_reviewerId",
                table: "Inquiries",
                column: "reviewerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
