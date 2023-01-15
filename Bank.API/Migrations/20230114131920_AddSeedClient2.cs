using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedClient2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("abde25ad-214c-4ce3-9016-b194082be6ad"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37846734-172e-4149-8cec-6f43d1eb3f60"),
                columns: new[] { "Email", "Name", "Surname" },
                values: new object[] { "klient.jeden@example.com", "Klient", "Jeden" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "pracownik.jeden01@gmail.com", "pracownik", "jeden" });

            migrationBuilder.InsertData(
                table: "GovernmentDocument",
                columns: new[] { "Id", "Description", "Name", "Number", "TypeId" },
                values: new object[] { new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611554"), "Passport", "Passport", "number", 2 });

            migrationBuilder.UpdateData(
                table: "JobDetails",
                keyColumn: "Id",
                keyValue: new Guid("46b087f9-5c71-401f-a5cf-021274463715"),
                column: "StartDate",
                value: new DateTime(2022, 8, 14, 14, 19, 20, 366, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.InsertData(
                table: "JobDetails",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate", "TypeId" },
                values: new object[] { new Guid("46b087f9-5c71-401f-a5cf-021274463751"), "Agent", new DateTime(2023, 1, 13, 14, 19, 20, 366, DateTimeKind.Local).AddTicks(235), "Agent", new DateTime(2021, 10, 14, 14, 19, 20, 366, DateTimeKind.Local).AddTicks(231), 37 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "GovernmentDocumentId", "JobDetailsId", "Name", "Surname" },
                values: new object[] { new Guid("37846734-172e-4149-8cec-6f43d1eb3f06"), "klient.dwa@example.com", new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611554"), new Guid("46b087f9-5c71-401f-a5cf-021274463751"), "Klient", "Dwa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37846734-172e-4149-8cec-6f43d1eb3f06"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "GovernmentDocument",
                keyColumn: "Id",
                keyValue: new Guid("9150ebd7-dd84-4c97-bf58-62f1c3611554"));

            migrationBuilder.DeleteData(
                table: "JobDetails",
                keyColumn: "Id",
                keyValue: new Guid("46b087f9-5c71-401f-a5cf-021274463751"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37846734-172e-4149-8cec-6f43d1eb3f60"),
                columns: new[] { "Email", "Name", "Surname" },
                values: new object[] { "imie.nazwisko@example.com", "imie", "nazwisko" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("abde25ad-214c-4ce3-9016-b194082be6ad"), "pracownik.jeden01@gmail.com", "pracownik", "jeden" });

            migrationBuilder.UpdateData(
                table: "JobDetails",
                keyColumn: "Id",
                keyValue: new Guid("46b087f9-5c71-401f-a5cf-021274463715"),
                column: "StartDate",
                value: new DateTime(2022, 8, 14, 14, 3, 7, 334, DateTimeKind.Local).AddTicks(5606));
        }
    }
}
