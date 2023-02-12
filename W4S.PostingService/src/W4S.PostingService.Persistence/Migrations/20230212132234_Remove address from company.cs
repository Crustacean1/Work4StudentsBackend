using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Removeaddressfromcompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("c55eee5c-7311-4e88-baaf-7c3c758835bb"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("dd8c52c8-5a0c-495a-b6df-5746da808147"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("b35ba8e7-213a-458b-aca4-22239fbeb292"));

            migrationBuilder.DropColumn(
                name: "Address_Building",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_Region",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("e49f7268-2dd6-4f4b-9709-c828373ae6b7"), "noreply@company.et", "John", "123456789", null, "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname" },
                values: new object[] { new Guid("935b10a7-f02d-4e8e-a9e6-729f3e38afe7"), new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"), "noreply@company.et", "John", "123456789", null, "Smith" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("e49f7268-2dd6-4f4b-9709-c828373ae6b7"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("935b10a7-f02d-4e8e-a9e6-729f3e38afe7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"));

            migrationBuilder.AddColumn<string>(
                name: "Address_Building",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Region",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("c55eee5c-7311-4e88-baaf-7c3c758835bb"), "noreply@company.et", "John", "123456789", null, "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "NIP", "Name", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("b35ba8e7-213a-458b-aca4-22239fbeb292"), "Hmmmmmm", "7821160955", "Company", "Macdonald", "Gliwice", "Poland", "Silesia", "Wrocławska" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname" },
                values: new object[] { new Guid("dd8c52c8-5a0c-495a-b6df-5746da808147"), new Guid("b35ba8e7-213a-458b-aca4-22239fbeb292"), "noreply@company.et", "John", "123456789", null, "Smith" });
        }
    }
}
