using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Locationextension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Latitude",
                table: "Recruiters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Longitude",
                table: "Recruiters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Latitude",
                table: "JobOffers",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Longitude",
                table: "JobOffers",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Latitude",
                table: "Applicants",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Address_Longitude",
                table: "Applicants",
                type: "numeric",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("8c86ce46-32f6-4d7e-914c-10e5a7977859"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "Boilding", "Gliwice", "Polandia", null, null, "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("fc203cd1-6185-4e17-ac41-0e78e81d8eaf"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("b29db4cc-2e63-47d9-89c5-887df4b2e945"), new Guid("fc203cd1-6185-4e17-ac41-0e78e81d8eaf"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "24", "Gliwice", "Polandia", null, null, "Silesia", "Wrocławska" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("8c86ce46-32f6-4d7e-914c-10e5a7977859"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("b29db4cc-2e63-47d9-89c5-887df4b2e945"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("fc203cd1-6185-4e17-ac41-0e78e81d8eaf"));

            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                table: "Applicants");

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
    }
}
