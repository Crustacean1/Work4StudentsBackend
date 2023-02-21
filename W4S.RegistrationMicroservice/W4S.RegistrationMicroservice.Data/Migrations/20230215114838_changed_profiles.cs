using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedprofiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("4e3fcfd4-c045-4567-836e-6f3b2f41f075"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("e678144b-054b-49ae-8e09-2cd788378f0d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("50c5f6f5-9b47-46b5-8e37-b1b2f5c81f59"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("63e27cdd-8bda-424e-9d57-e925db6c0086"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("c02db963-6039-4269-aec3-2934582f1fde"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("eff7e88c-8574-42f4-a024-f338cce776c0"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("bf0a8f1d-f9a9-4c33-bc90-90a04b6df3c7"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("e678144b-054b-49ae-8e09-2cd788378f0d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("eff7e88c-8574-42f4-a024-f338cce776c0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("60531adc-9dbe-40a1-b4e4-d79499c0d03b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e3fcfd4-c045-4567-836e-6f3b2f41f075"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("63e27cdd-8bda-424e-9d57-e925db6c0086"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("4e3fcfd4-c045-4567-836e-6f3b2f41f075"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6f9a02d1-8fa6-4863-8638-2c55510e45b1"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("50c5f6f5-9b47-46b5-8e37-b1b2f5c81f59"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("60531adc-9dbe-40a1-b4e4-d79499c0d03b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf0a8f1d-f9a9-4c33-bc90-90a04b6df3c7"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("60531adc-9dbe-40a1-b4e4-d79499c0d03b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("6f9a02d1-8fa6-4863-8638-2c55510e45b1"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("bf0a8f1d-f9a9-4c33-bc90-90a04b6df3c7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3e400f9e-4c57-441b-831a-4e129d5899e3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d0f24f1a-2b43-4e91-808a-c26a2f6696a1"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("c02db963-6039-4269-aec3-2934582f1fde"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("3e400f9e-4c57-441b-831a-4e129d5899e3"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("d0f24f1a-2b43-4e91-808a-c26a2f6696a1"));

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "StudentProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "StudentProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Education",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "StudentProfiles");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Profiles",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("63e27cdd-8bda-424e-9d57-e925db6c0086"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("3e400f9e-4c57-441b-831a-4e129d5899e3"),
                    new Guid("4e3fcfd4-c045-4567-836e-6f3b2f41f075"),
                    new Guid("50c5f6f5-9b47-46b5-8e37-b1b2f5c81f59"),
                    new Guid("60531adc-9dbe-40a1-b4e4-d79499c0d03b"),
                    new Guid("63e27cdd-8bda-424e-9d57-e925db6c0086"),
                    new Guid("6f9a02d1-8fa6-4863-8638-2c55510e45b1"),
                    new Guid("bf0a8f1d-f9a9-4c33-bc90-90a04b6df3c7"),
                    new Guid("c02db963-6039-4269-aec3-2934582f1fde"),
                    new Guid("d0f24f1a-2b43-4e91-808a-c26a2f6696a1")
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Building", "City", "Country", "Description", "Education", "EmailAddress", "Experience", "PhoneNumber", "PhotoFile", "Rating", "Region", "ShortDescription", "Street" },
                values: new object[,]
                {
                    { new Guid("e678144b-054b-49ae-8e09-2cd788378f0d"), "2a", "Gliwice", "Poland", "My company is the best.", "Bachelor in Milfology", "someEmployer@gmail.com", "5 years as Milfhunter", "2137", null, 0.0m, "Silesia", "My company...", "Akademicka" },
                    { new Guid("eff7e88c-8574-42f4-a024-f338cce776c0"), "2a", "Gliwice", "Poland", "My university is the best.", "Silesian University of Science, Informatics", "someEmployer@gmail.com", "20 years in Unity", "+2137", null, 0.0m, "Silesia", "My university...", "Akademicka" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("c02db963-6039-4269-aec3-2934582f1fde"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("3e400f9e-4c57-441b-831a-4e129d5899e3"), "Employer" },
                    { new Guid("6f9a02d1-8fa6-4863-8638-2c55510e45b1"), "Administrator" },
                    { new Guid("d0f24f1a-2b43-4e91-808a-c26a2f6696a1"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("50c5f6f5-9b47-46b5-8e37-b1b2f5c81f59"), new Guid("c02db963-6039-4269-aec3-2934582f1fde"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("4e3fcfd4-c045-4567-836e-6f3b2f41f075"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("6f9a02d1-8fa6-4863-8638-2c55510e45b1"), "Adminsky", "Akademicka", "Administator" },
                    { new Guid("60531adc-9dbe-40a1-b4e4-d79499c0d03b"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("d0f24f1a-2b43-4e91-808a-c26a2f6696a1"), "Karol", "Akademicka", "Pavulon" },
                    { new Guid("bf0a8f1d-f9a9-4c33-bc90-90a04b6df3c7"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("3e400f9e-4c57-441b-831a-4e129d5899e3"), "Szef", "Akademicka", "Małysz" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("4e3fcfd4-c045-4567-836e-6f3b2f41f075"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("bf0a8f1d-f9a9-4c33-bc90-90a04b6df3c7"), new Guid("63e27cdd-8bda-424e-9d57-e925db6c0086"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("60531adc-9dbe-40a1-b4e4-d79499c0d03b"), new Guid("50c5f6f5-9b47-46b5-8e37-b1b2f5c81f59") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "CompanyName", "EmployerId", "PositionName" },
                values: new object[] { new Guid("e678144b-054b-49ae-8e09-2cd788378f0d"), "Empty firm in Poland", new Guid("bf0a8f1d-f9a9-4c33-bc90-90a04b6df3c7"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("eff7e88c-8574-42f4-a024-f338cce776c0"), null, new Guid("60531adc-9dbe-40a1-b4e4-d79499c0d03b") });
        }
    }
}
