using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class photosAndResumeSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("28ceb4d1-1996-4764-bcea-8085f982b4ee"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6a2dd6ac-8133-427a-8002-146ba758dc15"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("50928514-93dc-432b-b607-ebc89014a535"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("6a2dd6ac-8133-427a-8002-146ba758dc15"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("aba0505f-9479-4c3d-944d-f2224f5fe72a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("180a20fb-8af3-47c4-8237-007766845e99"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b57dcb-1564-4a3d-b539-12f514e2e2d5"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("aba0505f-9479-4c3d-944d-f2224f5fe72a"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("180a20fb-8af3-47c4-8237-007766845e99"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("c0b57dcb-1564-4a3d-b539-12f514e2e2d5"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("50928514-93dc-432b-b607-ebc89014a535"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("28ceb4d1-1996-4764-bcea-8085f982b4ee"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("28ceb4d1-1996-4764-bcea-8085f982b4ee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("783c3dec-c9cf-4508-8671-738700b83e12"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("783c3dec-c9cf-4508-8671-738700b83e12"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("918bf2db-ede3-437c-b809-7f453bb45b07"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("1ab92666-e5ef-4287-a77c-4ca7ebba6f2e"),
                    new Guid("6abb49b9-f375-4b1a-b49e-43ca419b689a"),
                    new Guid("79687041-be55-47e5-9c93-3fd770621de1"),
                    new Guid("7b7a261a-8014-47a9-b754-82527f756c69"),
                    new Guid("918bf2db-ede3-437c-b809-7f453bb45b07"),
                    new Guid("c77b4c1d-f907-4b90-9f08-0ec8a750ee2e"),
                    new Guid("ea7d2e08-0bb9-4d6a-afe6-018dc1897091")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("c77b4c1d-f907-4b90-9f08-0ec8a750ee2e"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("6abb49b9-f375-4b1a-b49e-43ca419b689a"), "Employer" },
                    { new Guid("79687041-be55-47e5-9c93-3fd770621de1"), "Administrator" },
                    { new Guid("7b7a261a-8014-47a9-b754-82527f756c69"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("1ab92666-e5ef-4287-a77c-4ca7ebba6f2e"), new Guid("c77b4c1d-f907-4b90-9f08-0ec8a750ee2e"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[] { new Guid("ea7d2e08-0bb9-4d6a-afe6-018dc1897091"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("79687041-be55-47e5-9c93-3fd770621de1"), "Adminsky", "Akademicka", "Administator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("ea7d2e08-0bb9-4d6a-afe6-018dc1897091"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("ea7d2e08-0bb9-4d6a-afe6-018dc1897091"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("918bf2db-ede3-437c-b809-7f453bb45b07"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1ab92666-e5ef-4287-a77c-4ca7ebba6f2e"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("918bf2db-ede3-437c-b809-7f453bb45b07"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("c77b4c1d-f907-4b90-9f08-0ec8a750ee2e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6abb49b9-f375-4b1a-b49e-43ca419b689a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7b7a261a-8014-47a9-b754-82527f756c69"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("1ab92666-e5ef-4287-a77c-4ca7ebba6f2e"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("6abb49b9-f375-4b1a-b49e-43ca419b689a"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7b7a261a-8014-47a9-b754-82527f756c69"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("c77b4c1d-f907-4b90-9f08-0ec8a750ee2e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ea7d2e08-0bb9-4d6a-afe6-018dc1897091"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("ea7d2e08-0bb9-4d6a-afe6-018dc1897091"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79687041-be55-47e5-9c93-3fd770621de1"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("79687041-be55-47e5-9c93-3fd770621de1"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("6a2dd6ac-8133-427a-8002-146ba758dc15"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("180a20fb-8af3-47c4-8237-007766845e99"),
                    new Guid("28ceb4d1-1996-4764-bcea-8085f982b4ee"),
                    new Guid("50928514-93dc-432b-b607-ebc89014a535"),
                    new Guid("6a2dd6ac-8133-427a-8002-146ba758dc15"),
                    new Guid("783c3dec-c9cf-4508-8671-738700b83e12"),
                    new Guid("aba0505f-9479-4c3d-944d-f2224f5fe72a"),
                    new Guid("c0b57dcb-1564-4a3d-b539-12f514e2e2d5")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("50928514-93dc-432b-b607-ebc89014a535"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("180a20fb-8af3-47c4-8237-007766845e99"), "Employer" },
                    { new Guid("783c3dec-c9cf-4508-8671-738700b83e12"), "Administrator" },
                    { new Guid("c0b57dcb-1564-4a3d-b539-12f514e2e2d5"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("aba0505f-9479-4c3d-944d-f2224f5fe72a"), new Guid("50928514-93dc-432b-b607-ebc89014a535"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[] { new Guid("28ceb4d1-1996-4764-bcea-8085f982b4ee"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("783c3dec-c9cf-4508-8671-738700b83e12"), "Adminsky", "Akademicka", "Administator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("28ceb4d1-1996-4764-bcea-8085f982b4ee"));
        }
    }
}
