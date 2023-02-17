using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Changeupschedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("04ba9c77-4947-4a56-a478-25f39e91b736"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("4e6f427e-4387-4845-bd4b-b56889b680c1"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c75cae6e-77df-4445-9826-8b63ea51ecd5"));

            migrationBuilder.DropColumn(
                name: "End",
                table: "JobOffers_WorkingHours");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "JobOffers_WorkingHours");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Applicants_Availability");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Applicants_Availability");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "JobOffers_WorkingHours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "JobOffers_WorkingHours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartHour",
                table: "JobOffers_WorkingHours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Applicants_Availability",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Applicants_Availability",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartHour",
                table: "Applicants_Availability",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("2ecb83b1-51a7-400d-94c3-7bb205495de4"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "Boilding", "Gliwice", "Polandia", null, null, "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("d9259861-3b25-4e1d-becf-1c074670649d"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("56702110-98b5-451e-9ee7-8bcc5e883967"), new Guid("d9259861-3b25-4e1d-becf-1c074670649d"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "24", "Gliwice", "Polandia", null, null, "Silesia", "Wrocławska" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("2ecb83b1-51a7-400d-94c3-7bb205495de4"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("56702110-98b5-451e-9ee7-8bcc5e883967"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("d9259861-3b25-4e1d-becf-1c074670649d"));

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "JobOffers_WorkingHours");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "JobOffers_WorkingHours");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "JobOffers_WorkingHours");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Applicants_Availability");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Applicants_Availability");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "Applicants_Availability");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "JobOffers_WorkingHours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "JobOffers_WorkingHours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Applicants_Availability",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Applicants_Availability",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("04ba9c77-4947-4a56-a478-25f39e91b736"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "Boilding", "Gliwice", "Polandia", null, null, "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("c75cae6e-77df-4445-9826-8b63ea51ecd5"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("4e6f427e-4387-4845-bd4b-b56889b680c1"), new Guid("c75cae6e-77df-4445-9826-8b63ea51ecd5"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "24", "Gliwice", "Polandia", null, null, "Silesia", "Wrocławska" });
        }
    }
}
