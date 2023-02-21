using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedConstraintsandseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "EmailDomain",
                table: "UniversitiesDomains",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Universities",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[,]
                {
                    { new Guid("15433e9b-8a11-4fd1-a9d4-4fb821e07e88"), "1040000426", "ACHIMA POLSTERMOBELFABRIK GMBH,SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ" },
                    { new Guid("171404f4-53a9-478e-8d66-c3ee5bba0d94"), "9690207610", "Willa Avita Joanna Zięba" },
                    { new Guid("33773135-6802-4846-987b-a3cc467b8403"), "1130103940", "1) DIAMENT JOLANTA JAROSZEK 2) Jolanta Jaroszek wspólnik spółki cywilnej RJ CAR" },
                    { new Guid("754817e1-be46-461b-93cf-137f65e794fd"), "1050000244", "AUDACON SPÓŁKA AKCYJNA ODDZIAŁ W POLSCE" },
                    { new Guid("8bf4d287-15f1-4582-b1ce-4c72c0412ba2"), "1070008183", "1 A PHARMA GMBH SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ ODDZIAŁ W POLSCE W LIKWIDACJI" },
                    { new Guid("8fab8652-e890-4824-9c72-40931d2c87aa"), "1181816779", "Medical Care24 Ewelina Dąbrowska" },
                    { new Guid("a380a16e-a882-4507-a03f-bf7860bcb5cf"), "759114060", "Avanti Capital Leasing" },
                    { new Guid("ba393e12-c0f5-4b07-bf52-8198f85b9d5b"), "1010000108", "MAAS HOLDING GMBH (SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ) ODDZIAŁ W POLSCE" },
                    { new Guid("bf38504d-b602-409e-8e46-c3d9ee5e9b59"), "5283121250", "Empty firm in Poland" },
                    { new Guid("f3a3b1c6-0ee5-404c-ad0a-533ccb2b0345"), "951643196", "Agencja Ochrony Pracy Kwiatkowska" }
                });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("11a0f4e3-0952-4a57-b7cd-c008835ce6a8"),
                    new Guid("15433e9b-8a11-4fd1-a9d4-4fb821e07e88"),
                    new Guid("171404f4-53a9-478e-8d66-c3ee5bba0d94"),
                    new Guid("1762f694-000d-42b5-b857-cddca8557528"),
                    new Guid("28fa738e-0a16-4109-9f07-0d7c4d541989"),
                    new Guid("33773135-6802-4846-987b-a3cc467b8403"),
                    new Guid("4ae80416-5942-4990-9de2-1d720ce22a77"),
                    new Guid("5cde1509-686c-4a20-b6b0-ce64be33187f"),
                    new Guid("6cf93dad-7116-444c-a8f1-5d44376dcd77"),
                    new Guid("754817e1-be46-461b-93cf-137f65e794fd"),
                    new Guid("8bf4d287-15f1-4582-b1ce-4c72c0412ba2"),
                    new Guid("8fab8652-e890-4824-9c72-40931d2c87aa"),
                    new Guid("91f91245-66cd-4f18-a7d3-f65a4d5e0099"),
                    new Guid("99ef9de8-2af7-4392-8971-106b2eb9cb83"),
                    new Guid("a380a16e-a882-4507-a03f-bf7860bcb5cf"),
                    new Guid("ae95f6f6-d8a9-4f3c-ac31-ebc9f2a995f6"),
                    new Guid("ba393e12-c0f5-4b07-bf52-8198f85b9d5b"),
                    new Guid("bf38504d-b602-409e-8e46-c3d9ee5e9b59"),
                    new Guid("c13258e5-3f37-4e6f-a2d9-0db2a8ba7ba3"),
                    new Guid("cbbaf663-103e-4bd8-a82a-b8461aa2d4d7"),
                    new Guid("e075c623-840d-4e06-876e-e84bdc70981c"),
                    new Guid("e69d0d95-220e-4ea1-911f-49e65f212c3d"),
                    new Guid("ee29a480-6f02-4677-993d-5cfd1af7c707"),
                    new Guid("f3a3b1c6-0ee5-404c-ad0a-533ccb2b0345")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[,]
                {
                    { new Guid("11a0f4e3-0952-4a57-b7cd-c008835ce6a8"), "@student.polsl.pl" },
                    { new Guid("4ae80416-5942-4990-9de2-1d720ce22a77"), "@polsl.pl" },
                    { new Guid("5cde1509-686c-4a20-b6b0-ce64be33187f"), "@student.uj.edu.pl" },
                    { new Guid("cbbaf663-103e-4bd8-a82a-b8461aa2d4d7"), "@student.agh.edu.pl" },
                    { new Guid("ee29a480-6f02-4677-993d-5cfd1af7c707"), "@student.uek.krakow.pl" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("6cf93dad-7116-444c-a8f1-5d44376dcd77"), "Administrator" },
                    { new Guid("91f91245-66cd-4f18-a7d3-f65a4d5e0099"), "Employer" },
                    { new Guid("c13258e5-3f37-4e6f-a2d9-0db2a8ba7ba3"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[,]
                {
                    { new Guid("1762f694-000d-42b5-b857-cddca8557528"), new Guid("cbbaf663-103e-4bd8-a82a-b8461aa2d4d7"), "AGH University of Science and Technology" },
                    { new Guid("28fa738e-0a16-4109-9f07-0d7c4d541989"), new Guid("11a0f4e3-0952-4a57-b7cd-c008835ce6a8"), "Silesian Technical University of Gliwice" },
                    { new Guid("ae95f6f6-d8a9-4f3c-ac31-ebc9f2a995f6"), new Guid("ee29a480-6f02-4677-993d-5cfd1af7c707"), "Cracow University of Economics" },
                    { new Guid("e075c623-840d-4e06-876e-e84bdc70981c"), new Guid("4ae80416-5942-4990-9de2-1d720ce22a77"), "Politechnika Śląska" },
                    { new Guid("e69d0d95-220e-4ea1-911f-49e65f212c3d"), new Guid("5cde1509-686c-4a20-b6b0-ce64be33187f"), "Jagellonian University" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[] { new Guid("99ef9de8-2af7-4392-8971-106b2eb9cb83"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("6cf93dad-7116-444c-a8f1-5d44376dcd77"), "Adminsky", "Akademicka", "Administator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("99ef9de8-2af7-4392-8971-106b2eb9cb83"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("99ef9de8-2af7-4392-8971-106b2eb9cb83"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("15433e9b-8a11-4fd1-a9d4-4fb821e07e88"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("171404f4-53a9-478e-8d66-c3ee5bba0d94"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("33773135-6802-4846-987b-a3cc467b8403"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("754817e1-be46-461b-93cf-137f65e794fd"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8bf4d287-15f1-4582-b1ce-4c72c0412ba2"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8fab8652-e890-4824-9c72-40931d2c87aa"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a380a16e-a882-4507-a03f-bf7860bcb5cf"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("ba393e12-c0f5-4b07-bf52-8198f85b9d5b"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bf38504d-b602-409e-8e46-c3d9ee5e9b59"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("f3a3b1c6-0ee5-404c-ad0a-533ccb2b0345"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("11a0f4e3-0952-4a57-b7cd-c008835ce6a8"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("15433e9b-8a11-4fd1-a9d4-4fb821e07e88"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("171404f4-53a9-478e-8d66-c3ee5bba0d94"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1762f694-000d-42b5-b857-cddca8557528"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("28fa738e-0a16-4109-9f07-0d7c4d541989"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("33773135-6802-4846-987b-a3cc467b8403"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("4ae80416-5942-4990-9de2-1d720ce22a77"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("5cde1509-686c-4a20-b6b0-ce64be33187f"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("754817e1-be46-461b-93cf-137f65e794fd"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("8bf4d287-15f1-4582-b1ce-4c72c0412ba2"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("8fab8652-e890-4824-9c72-40931d2c87aa"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("a380a16e-a882-4507-a03f-bf7860bcb5cf"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("ae95f6f6-d8a9-4f3c-ac31-ebc9f2a995f6"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("ba393e12-c0f5-4b07-bf52-8198f85b9d5b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("bf38504d-b602-409e-8e46-c3d9ee5e9b59"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("cbbaf663-103e-4bd8-a82a-b8461aa2d4d7"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("e075c623-840d-4e06-876e-e84bdc70981c"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("e69d0d95-220e-4ea1-911f-49e65f212c3d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("ee29a480-6f02-4677-993d-5cfd1af7c707"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("f3a3b1c6-0ee5-404c-ad0a-533ccb2b0345"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("91f91245-66cd-4f18-a7d3-f65a4d5e0099"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c13258e5-3f37-4e6f-a2d9-0db2a8ba7ba3"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("1762f694-000d-42b5-b857-cddca8557528"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("28fa738e-0a16-4109-9f07-0d7c4d541989"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("ae95f6f6-d8a9-4f3c-ac31-ebc9f2a995f6"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("e075c623-840d-4e06-876e-e84bdc70981c"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("e69d0d95-220e-4ea1-911f-49e65f212c3d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("91f91245-66cd-4f18-a7d3-f65a4d5e0099"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("c13258e5-3f37-4e6f-a2d9-0db2a8ba7ba3"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("11a0f4e3-0952-4a57-b7cd-c008835ce6a8"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("4ae80416-5942-4990-9de2-1d720ce22a77"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("5cde1509-686c-4a20-b6b0-ce64be33187f"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("cbbaf663-103e-4bd8-a82a-b8461aa2d4d7"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("ee29a480-6f02-4677-993d-5cfd1af7c707"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("99ef9de8-2af7-4392-8971-106b2eb9cb83"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("99ef9de8-2af7-4392-8971-106b2eb9cb83"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6cf93dad-7116-444c-a8f1-5d44376dcd77"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("6cf93dad-7116-444c-a8f1-5d44376dcd77"));

            migrationBuilder.AlterColumn<string>(
                name: "EmailDomain",
                table: "UniversitiesDomains",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Universities",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
