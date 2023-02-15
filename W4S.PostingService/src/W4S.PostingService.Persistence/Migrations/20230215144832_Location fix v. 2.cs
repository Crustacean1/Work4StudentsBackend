using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Locationfixv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Applications",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("6dfe3606-a4c7-4f77-a1e1-ea73fbedff8b"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "Boilding", "Gliwice", "Polandia", null, null, "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("525a029f-53f8-42e4-9017-80c196451557"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("c6ea42c5-a38b-4472-958f-449254d0df32"), new Guid("525a029f-53f8-42e4-9017-80c196451557"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "24", "Gliwice", "Polandia", null, null, "Silesia", "Wrocławska" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("6dfe3606-a4c7-4f77-a1e1-ea73fbedff8b"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("c6ea42c5-a38b-4472-958f-449254d0df32"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("525a029f-53f8-42e4-9017-80c196451557"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Distance",
                table: "Applications",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

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
    }
}
