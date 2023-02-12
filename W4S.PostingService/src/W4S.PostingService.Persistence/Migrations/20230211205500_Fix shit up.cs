using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixshitup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Availability_Applicants_ApplicantId",
                table: "Applicants_Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications");

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
                name: "Openings",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "LastChange",
                table: "Applications",
                newName: "LastChanged");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "Applications",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ApplicantId",
                table: "Applications",
                newName: "IX_Applications_StudentId");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "Applicants_Availability",
                newName: "StudentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "JobOffers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Availability_Applicants_StudentId",
                table: "Applicants_Availability",
                column: "StudentId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_StudentId",
                table: "Applications",
                column: "StudentId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Availability_Applicants_StudentId",
                table: "Applicants_Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_StudentId",
                table: "Applications");

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
                name: "CreationDate",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Applications",
                newName: "ApplicantId");

            migrationBuilder.RenameColumn(
                name: "LastChanged",
                table: "Applications",
                newName: "LastChange");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_StudentId",
                table: "Applications",
                newName: "IX_Applications_ApplicantId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Applicants_Availability",
                newName: "ApplicantId");

            migrationBuilder.AddColumn<long>(
                name: "Openings",
                table: "JobOffers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Availability_Applicants_ApplicantId",
                table: "Applicants_Availability",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
