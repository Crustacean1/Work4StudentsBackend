using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addnip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("84970053-0cdb-4438-8812-7a4a581b2452"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("815a4216-3e5b-4b84-9afc-ff099763fd59"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2badd62b-ddd2-4f46-9a5b-3f8f37c91ea8"));

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Recruiters",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Applicants",
                newName: "EmailAddress");

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Recruiters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIP",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Applicants",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("7148bf79-e2bd-4d48-b979-fb7f89a106f2"), "noreply@company.et", "John", "123456789", null, "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "NIP", "Name", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("334b1847-0f07-4479-adcd-5731831fd5c7"), "Hmmmmmm", "7821160955", "Company", "Macdonald", "Gliwice", "Poland", "Silesia", "Wrocławska" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname" },
                values: new object[] { new Guid("753d9460-1565-471a-8eeb-0aef2afc7fca"), new Guid("334b1847-0f07-4479-adcd-5731831fd5c7"), "noreply@company.et", "John", "123456789", null, "Smith" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("7148bf79-e2bd-4d48-b979-fb7f89a106f2"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("753d9460-1565-471a-8eeb-0aef2afc7fca"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("334b1847-0f07-4479-adcd-5731831fd5c7"));

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "NIP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Recruiters",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Applicants",
                newName: "Email");

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "Email", "FirstName", "PhoneNumber", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("84970053-0cdb-4438-8812-7a4a581b2452"), "noreply@company.et", "John", "123456789", "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("2badd62b-ddd2-4f46-9a5b-3f8f37c91ea8"), "It is what it is", "Company", "Macdonald", "Gliwice", "Poland", "Silesia", "Wrocławska" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "PhoneNumber", "Surname" },
                values: new object[] { new Guid("815a4216-3e5b-4b84-9afc-ff099763fd59"), new Guid("2badd62b-ddd2-4f46-9a5b-3f8f37c91ea8"), "noreply@company.et", "John", "123456789", "Smith" });
        }
    }
}
