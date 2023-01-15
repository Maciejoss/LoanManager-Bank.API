using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("8dbcaef1-1f56-44a2-ac1b-0bfdee1832d0"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("abde25ad-214c-4ce3-9016-b194082be6ad"), "pracownik.jeden01@gmail.com", "pracownik", "jeden" });

            migrationBuilder.InsertData(
                table: "GovernmentDocument",
                columns: new[] { "Id", "Description", "Name", "Number", "TypeId" },
                values: new object[] { new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611545"), "Driver License", "Driver License", "number", 1 });

            migrationBuilder.InsertData(
                table: "JobDetails",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate", "TypeId" },
                values: new object[] { new Guid("46b087f9-5c71-401f-a5cf-021274463715"), "Director", null, "Director", new DateTime(2022, 8, 14, 14, 3, 7, 334, DateTimeKind.Local).AddTicks(5606), 30 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "GovernmentDocumentId", "JobDetailsId", "Name", "Surname" },
                values: new object[] { new Guid("37846734-172e-4149-8cec-6f43d1eb3f60"), "imie.nazwisko@example.com", new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611545"), new Guid("46b087f9-5c71-401f-a5cf-021274463715"), "imie", "nazwisko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37846734-172e-4149-8cec-6f43d1eb3f60"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("abde25ad-214c-4ce3-9016-b194082be6ad"));

            migrationBuilder.DeleteData(
                table: "GovernmentDocument",
                keyColumn: "Id",
                keyValue: new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611545"));

            migrationBuilder.DeleteData(
                table: "JobDetails",
                keyColumn: "Id",
                keyValue: new Guid("46b087f9-5c71-401f-a5cf-021274463715"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("8dbcaef1-1f56-44a2-ac1b-0bfdee1832d0"), "pracownik.jeden01@gmail.com", "pracownik", "jeden" });
        }
    }
}
