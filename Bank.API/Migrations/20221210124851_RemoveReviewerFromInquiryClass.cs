using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReviewerFromInquiryClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Employees_ReviewerId",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_ReviewerId",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Inquiries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReviewerId",
                table: "Inquiries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_ReviewerId",
                table: "Inquiries",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Employees_ReviewerId",
                table: "Inquiries",
                column: "ReviewerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
