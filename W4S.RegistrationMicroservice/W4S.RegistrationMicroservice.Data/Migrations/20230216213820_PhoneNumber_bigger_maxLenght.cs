using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumberbiggermaxLenght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("9eadc790-0706-4659-852b-f0d21e87ae63"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("cfb6b059-ec9d-4049-bcae-5a879a7cb065"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1cf48f4f-def6-4b2f-b598-a7506a5bea54"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("870c1b80-0a1b-4ef8-8a45-2268cd8345d4"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("cfb6b059-ec9d-4049-bcae-5a879a7cb065"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1804d378-69ba-4b11-9be9-8b9f9e7079c2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb6f95de-7cdb-4a0c-a939-9a7ce605bde6"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("870c1b80-0a1b-4ef8-8a45-2268cd8345d4"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1804d378-69ba-4b11-9be9-8b9f9e7079c2"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("eb6f95de-7cdb-4a0c-a939-9a7ce605bde6"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("1cf48f4f-def6-4b2f-b598-a7506a5bea54"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9eadc790-0706-4659-852b-f0d21e87ae63"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("9eadc790-0706-4659-852b-f0d21e87ae63"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("401d8379-b5c4-43cc-b697-cbd740f633de"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("401d8379-b5c4-43cc-b697-cbd740f633de"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("289a090d-91e5-46ff-a4e6-933571d6733b"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("1c1987a5-d5af-43e6-97d9-7cc886c08f61"),
                    new Guid("289a090d-91e5-46ff-a4e6-933571d6733b"),
                    new Guid("33217a56-ca8a-4e15-aae5-dc7f223dbae9"),
                    new Guid("3440b5e3-94d0-4fa2-b138-4b60fe79942b"),
                    new Guid("7adc31ec-b4a2-43d7-aafb-3d81bf543741"),
                    new Guid("d3dba7a5-e7e4-45b9-a268-7ca10f159ac9"),
                    new Guid("e406e74f-c1c3-48de-9caa-8734cc046537")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("e406e74f-c1c3-48de-9caa-8734cc046537"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("1c1987a5-d5af-43e6-97d9-7cc886c08f61"), "Employer" },
                    { new Guid("7adc31ec-b4a2-43d7-aafb-3d81bf543741"), "Administrator" },
                    { new Guid("d3dba7a5-e7e4-45b9-a268-7ca10f159ac9"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("33217a56-ca8a-4e15-aae5-dc7f223dbae9"), new Guid("e406e74f-c1c3-48de-9caa-8734cc046537"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[] { new Guid("3440b5e3-94d0-4fa2-b138-4b60fe79942b"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("7adc31ec-b4a2-43d7-aafb-3d81bf543741"), "Adminsky", "Akademicka", "Administator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("3440b5e3-94d0-4fa2-b138-4b60fe79942b"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("3440b5e3-94d0-4fa2-b138-4b60fe79942b"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("289a090d-91e5-46ff-a4e6-933571d6733b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("289a090d-91e5-46ff-a4e6-933571d6733b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("33217a56-ca8a-4e15-aae5-dc7f223dbae9"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("e406e74f-c1c3-48de-9caa-8734cc046537"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1c1987a5-d5af-43e6-97d9-7cc886c08f61"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d3dba7a5-e7e4-45b9-a268-7ca10f159ac9"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("33217a56-ca8a-4e15-aae5-dc7f223dbae9"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1c1987a5-d5af-43e6-97d9-7cc886c08f61"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("d3dba7a5-e7e4-45b9-a268-7ca10f159ac9"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("e406e74f-c1c3-48de-9caa-8734cc046537"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3440b5e3-94d0-4fa2-b138-4b60fe79942b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("3440b5e3-94d0-4fa2-b138-4b60fe79942b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7adc31ec-b4a2-43d7-aafb-3d81bf543741"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7adc31ec-b4a2-43d7-aafb-3d81bf543741"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("cfb6b059-ec9d-4049-bcae-5a879a7cb065"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("1804d378-69ba-4b11-9be9-8b9f9e7079c2"),
                    new Guid("1cf48f4f-def6-4b2f-b598-a7506a5bea54"),
                    new Guid("401d8379-b5c4-43cc-b697-cbd740f633de"),
                    new Guid("870c1b80-0a1b-4ef8-8a45-2268cd8345d4"),
                    new Guid("9eadc790-0706-4659-852b-f0d21e87ae63"),
                    new Guid("cfb6b059-ec9d-4049-bcae-5a879a7cb065"),
                    new Guid("eb6f95de-7cdb-4a0c-a939-9a7ce605bde6")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("1cf48f4f-def6-4b2f-b598-a7506a5bea54"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("1804d378-69ba-4b11-9be9-8b9f9e7079c2"), "Student" },
                    { new Guid("401d8379-b5c4-43cc-b697-cbd740f633de"), "Administrator" },
                    { new Guid("eb6f95de-7cdb-4a0c-a939-9a7ce605bde6"), "Employer" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("870c1b80-0a1b-4ef8-8a45-2268cd8345d4"), new Guid("1cf48f4f-def6-4b2f-b598-a7506a5bea54"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[] { new Guid("9eadc790-0706-4659-852b-f0d21e87ae63"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("401d8379-b5c4-43cc-b697-cbd740f633de"), "Adminsky", "Akademicka", "Administator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("9eadc790-0706-4659-852b-f0d21e87ae63"));
        }
    }
}
