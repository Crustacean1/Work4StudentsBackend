using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Ratings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("ad10a94c-18cf-443d-a137-f8ecd45830e3"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("33fd39f4-3d59-4ca5-ab85-08cea4360451"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("15f641b1-2823-47ca-85a8-3d9987443597"));

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Recruiters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Applicants",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("95935e7f-14ca-40e4-b2fe-dc76897fd4d2"), "noreply@company.et", "John", "123456789", 0m, "", "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("3cf0ccfc-3d7a-456b-9c94-39166906b1db"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("c79f3320-8e6a-40a6-8e97-3797510dcdde"), new Guid("3cf0ccfc-3d7a-456b-9c94-39166906b1db"), "noreply@company.et", "John", "123456789", 0m, "", "Smith", "24", "Gliwice", "Polandia", "Silesia", "Wrocławska" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("95935e7f-14ca-40e4-b2fe-dc76897fd4d2"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("c79f3320-8e6a-40a6-8e97-3797510dcdde"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("3cf0ccfc-3d7a-456b-9c94-39166906b1db"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Applicants");

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("ad10a94c-18cf-443d-a137-f8ecd45830e3"), "noreply@company.et", "John", "123456789", "", "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("15f641b1-2823-47ca-85a8-3d9987443597"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("33fd39f4-3d59-4ca5-ab85-08cea4360451"), new Guid("15f641b1-2823-47ca-85a8-3d9987443597"), "noreply@company.et", "John", "123456789", "", "Smith", "24", "Gliwice", "Polandia", "Silesia", "Wrocławska" });
        }
    }
}
