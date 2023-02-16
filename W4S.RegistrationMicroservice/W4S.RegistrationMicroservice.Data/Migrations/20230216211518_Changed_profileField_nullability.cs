using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedprofileFieldnullability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("acf450be-d884-433b-b47c-e5e5ab46eea7"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("e68a2f0b-3ce7-443c-8dda-1187f0d461b6"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("47eb310b-225f-4e79-9eb0-fc0f38e6625e"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("69a8e092-6fa4-49d3-93ae-ebd5d3e5a133"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("6e7bdb45-83f8-4c04-8cbd-1853ddea0d47"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("5aca40d4-f391-482e-8ba7-a283810bb41a"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("7e0581fd-6e81-4ce1-b23c-7578d66ab91b"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("5aca40d4-f391-482e-8ba7-a283810bb41a"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("e68a2f0b-3ce7-443c-8dda-1187f0d461b6"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("738211d8-273b-4c10-a129-573f8fb6a34a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("acf450be-d884-433b-b47c-e5e5ab46eea7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6e7bdb45-83f8-4c04-8cbd-1853ddea0d47"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("acf450be-d884-433b-b47c-e5e5ab46eea7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("36d7c5bc-a32f-4f3e-80f7-da298e2e8966"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("47eb310b-225f-4e79-9eb0-fc0f38e6625e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("738211d8-273b-4c10-a129-573f8fb6a34a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e0581fd-6e81-4ce1-b23c-7578d66ab91b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("36d7c5bc-a32f-4f3e-80f7-da298e2e8966"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("738211d8-273b-4c10-a129-573f8fb6a34a"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7e0581fd-6e81-4ce1-b23c-7578d66ab91b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6e392e85-fcaf-4c3c-bdb3-708321e7c11a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9421b086-4ee5-47dd-97bd-6b746ffa20bd"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("69a8e092-6fa4-49d3-93ae-ebd5d3e5a133"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("6e392e85-fcaf-4c3c-bdb3-708321e7c11a"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("9421b086-4ee5-47dd-97bd-6b746ffa20bd"));

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "StudentProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "StudentProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Experience",
                table: "StudentProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "StudentProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("6e7bdb45-83f8-4c04-8cbd-1853ddea0d47"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("36d7c5bc-a32f-4f3e-80f7-da298e2e8966"),
                    new Guid("47eb310b-225f-4e79-9eb0-fc0f38e6625e"),
                    new Guid("69a8e092-6fa4-49d3-93ae-ebd5d3e5a133"),
                    new Guid("6e392e85-fcaf-4c3c-bdb3-708321e7c11a"),
                    new Guid("6e7bdb45-83f8-4c04-8cbd-1853ddea0d47"),
                    new Guid("738211d8-273b-4c10-a129-573f8fb6a34a"),
                    new Guid("7e0581fd-6e81-4ce1-b23c-7578d66ab91b"),
                    new Guid("9421b086-4ee5-47dd-97bd-6b746ffa20bd"),
                    new Guid("acf450be-d884-433b-b47c-e5e5ab46eea7")
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Building", "City", "Country", "Description", "EmailAddress", "PhoneNumber", "PhotoFile", "Rating", "Region", "Street" },
                values: new object[,]
                {
                    { new Guid("5aca40d4-f391-482e-8ba7-a283810bb41a"), "2a", "Gliwice", "Poland", "My university is the best.", "someEmployer@gmail.com", "+2137", null, 0.0m, "Silesia", "Akademicka" },
                    { new Guid("e68a2f0b-3ce7-443c-8dda-1187f0d461b6"), "2a", "Gliwice", "Poland", "My company is the best.", "someEmployer@gmail.com", "2137", null, 0.0m, "Silesia", "Akademicka" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("69a8e092-6fa4-49d3-93ae-ebd5d3e5a133"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("36d7c5bc-a32f-4f3e-80f7-da298e2e8966"), "Administrator" },
                    { new Guid("6e392e85-fcaf-4c3c-bdb3-708321e7c11a"), "Employer" },
                    { new Guid("9421b086-4ee5-47dd-97bd-6b746ffa20bd"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("47eb310b-225f-4e79-9eb0-fc0f38e6625e"), new Guid("69a8e092-6fa4-49d3-93ae-ebd5d3e5a133"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("738211d8-273b-4c10-a129-573f8fb6a34a"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("9421b086-4ee5-47dd-97bd-6b746ffa20bd"), "Karol", "Akademicka", "Pavulon" },
                    { new Guid("7e0581fd-6e81-4ce1-b23c-7578d66ab91b"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("6e392e85-fcaf-4c3c-bdb3-708321e7c11a"), "Szef", "Akademicka", "Małysz" },
                    { new Guid("acf450be-d884-433b-b47c-e5e5ab46eea7"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("36d7c5bc-a32f-4f3e-80f7-da298e2e8966"), "Adminsky", "Akademicka", "Administator" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("acf450be-d884-433b-b47c-e5e5ab46eea7"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("7e0581fd-6e81-4ce1-b23c-7578d66ab91b"), new Guid("6e7bdb45-83f8-4c04-8cbd-1853ddea0d47"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("738211d8-273b-4c10-a129-573f8fb6a34a"), new Guid("47eb310b-225f-4e79-9eb0-fc0f38e6625e") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "CompanyName", "EmployerId", "PositionName" },
                values: new object[] { new Guid("e68a2f0b-3ce7-443c-8dda-1187f0d461b6"), "Empty firm in Poland", new Guid("7e0581fd-6e81-4ce1-b23c-7578d66ab91b"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "Education", "Experience", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("5aca40d4-f391-482e-8ba7-a283810bb41a"), "Silesian University of Science, Informatics", "20 years in Unity", null, new Guid("738211d8-273b-4c10-a129-573f8fb6a34a") });
        }
    }
}
