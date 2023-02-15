using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Locationfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Proximity",
                table: "Applications",
                newName: "Distance");

            migrationBuilder.AlterColumn<double>(
                name: "Address_Longitude",
                table: "Recruiters",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Address_Latitude",
                table: "Recruiters",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Address_Longitude",
                table: "JobOffers",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Address_Latitude",
                table: "JobOffers",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Address_Longitude",
                table: "Applicants",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Address_Latitude",
                table: "Applicants",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("7942ae51-6efd-4dc0-938f-3ac3d15e4427"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "Boilding", "Gliwice", "Polandia", null, null, "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("b1362ece-63fd-4b29-b07f-b80fa90dda2b"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("0e6f0063-f4cd-450c-ae69-ad0979cf8098"), new Guid("b1362ece-63fd-4b29-b07f-b80fa90dda2b"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "24", "Gliwice", "Polandia", null, null, "Silesia", "Wrocławska" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("7942ae51-6efd-4dc0-938f-3ac3d15e4427"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("0e6f0063-f4cd-450c-ae69-ad0979cf8098"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("b1362ece-63fd-4b29-b07f-b80fa90dda2b"));

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Applications",
                newName: "Proximity");

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Longitude",
                table: "Recruiters",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Latitude",
                table: "Recruiters",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Longitude",
                table: "JobOffers",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Latitude",
                table: "JobOffers",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Longitude",
                table: "Applicants",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Address_Latitude",
                table: "Applicants",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

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
    }
}
