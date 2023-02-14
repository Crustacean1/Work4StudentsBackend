using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullableavaiability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("52d5f876-7f6d-4441-989a-d509973f829d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52d5f876-7f6d-4441-989a-d509973f829d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("52d5f876-7f6d-4441-989a-d509973f829d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"),
                    new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"),
                    new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"),
                    new Guid("52d5f876-7f6d-4441-989a-d509973f829d"),
                    new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"),
                    new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"),
                    new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"),
                    new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"),
                    new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554")
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Building", "City", "Country", "Description", "Education", "EmailAddress", "Experience", "PhoneNumber", "PhotoFile", "Rating", "Region", "ShortDescription", "Street" },
                values: new object[,]
                {
                    { new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"), "2a", "Gliwice", "Poland", "My company is the best.", "Bachelor in Milfology", "someEmployer@gmail.com", "5 years as Milfhunter", "2137", null, 0.0m, "Silesia", "My company...", "Akademicka" },
                    { new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"), "2a", "Gliwice", "Poland", "My university is the best.", "Silesian University of Science, Informatics", "someEmployer@gmail.com", "20 years in Unity", "+2137", null, 0.0m, "Silesia", "My university...", "Akademicka" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"), "Student" },
                    { new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"), "Administrator" },
                    { new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"), "Employer" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"), new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"), "Adminsky", "Akademicka", "Administator" },
                    { new Guid("52d5f876-7f6d-4441-989a-d509973f829d"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"), "Szef", "Akademicka", "Małysz" },
                    { new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"), "Karol", "Akademicka", "Pavulon" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("52d5f876-7f6d-4441-989a-d509973f829d"), new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"), new Guid("7172c284-148e-49c6-940e-0cecf7f9e512") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "CompanyName", "EmployerId", "PositionName" },
                values: new object[] { new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"), "Empty firm in Poland", new Guid("52d5f876-7f6d-4441-989a-d509973f829d"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"), null, new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5") });
        }
    }
}
