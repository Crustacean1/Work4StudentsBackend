using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingcorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("1d5d260b-8028-4b1e-a80d-66bdfb71e442"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("968d3d99-fa6a-49af-b094-a1d94f183d32"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("47d63cac-5791-4797-859c-ab2e0cd7a96b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("99a598f7-4d31-4679-bc0a-d516e324aebd"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("adec62d0-1a5c-4284-875a-602059f50add"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2cb1a814-cd37-4ada-8595-a48a4c1b6bfb"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("47d63cac-5791-4797-859c-ab2e0cd7a96b"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("adec62d0-1a5c-4284-875a-602059f50add"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d5d260b-8028-4b1e-a80d-66bdfb71e442"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2cb1a814-cd37-4ada-8595-a48a4c1b6bfb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("968d3d99-fa6a-49af-b094-a1d94f183d32"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1d5d260b-8028-4b1e-a80d-66bdfb71e442"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("2cb1a814-cd37-4ada-8595-a48a4c1b6bfb"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("968d3d99-fa6a-49af-b094-a1d94f183d32"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("23752845-42b6-4700-b7cf-9345234a0651"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75ee1dca-f171-4eef-bb57-999c55f3da0b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fd482647-c182-429f-9514-eedad9ce7997"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("99a598f7-4d31-4679-bc0a-d516e324aebd"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("23752845-42b6-4700-b7cf-9345234a0651"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("75ee1dca-f171-4eef-bb57-999c55f3da0b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("fd482647-c182-429f-9514-eedad9ce7997"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("49ca6967-22e2-4c79-9209-8734642faf7b"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("18bc9f78-2859-4300-8dff-721798f77efc"),
                    new Guid("248f6a5c-231e-48b5-9c9b-a137c0001758"),
                    new Guid("2c0571f6-3f8b-4da5-9494-36ae9179aa5d"),
                    new Guid("49ca6967-22e2-4c79-9209-8734642faf7b"),
                    new Guid("849c45bd-40db-4abc-8bdc-f7eaaa8d13d8"),
                    new Guid("a0b0e38f-6377-4f62-806a-a27602602070"),
                    new Guid("b7d7c5b5-c3f8-424e-ae90-c41bcb7cc2dd"),
                    new Guid("f8b697a6-f852-4f5e-9f0c-debb9975c816"),
                    new Guid("fc29b15d-32be-4959-91f4-da740dd72f6f")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("f8b697a6-f852-4f5e-9f0c-debb9975c816"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("248f6a5c-231e-48b5-9c9b-a137c0001758"), "Administrator" },
                    { new Guid("2c0571f6-3f8b-4da5-9494-36ae9179aa5d"), "Student" },
                    { new Guid("fc29b15d-32be-4959-91f4-da740dd72f6f"), "Employer" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("b7d7c5b5-c3f8-424e-ae90-c41bcb7cc2dd"), new Guid("f8b697a6-f852-4f5e-9f0c-debb9975c816"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("18bc9f78-2859-4300-8dff-721798f77efc"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("2c0571f6-3f8b-4da5-9494-36ae9179aa5d"), "Karol", "Akademicka", "Pavulon" },
                    { new Guid("849c45bd-40db-4abc-8bdc-f7eaaa8d13d8"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("fc29b15d-32be-4959-91f4-da740dd72f6f"), "Szef", "Akademicka", "Małysz" },
                    { new Guid("a0b0e38f-6377-4f62-806a-a27602602070"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("248f6a5c-231e-48b5-9c9b-a137c0001758"), "Adminsky", "Akademicka", "Administator" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("a0b0e38f-6377-4f62-806a-a27602602070"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("849c45bd-40db-4abc-8bdc-f7eaaa8d13d8"), new Guid("49ca6967-22e2-4c79-9209-8734642faf7b"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("18bc9f78-2859-4300-8dff-721798f77efc"), new Guid("b7d7c5b5-c3f8-424e-ae90-c41bcb7cc2dd") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("a0b0e38f-6377-4f62-806a-a27602602070"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("849c45bd-40db-4abc-8bdc-f7eaaa8d13d8"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("49ca6967-22e2-4c79-9209-8734642faf7b"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("b7d7c5b5-c3f8-424e-ae90-c41bcb7cc2dd"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("f8b697a6-f852-4f5e-9f0c-debb9975c816"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("18bc9f78-2859-4300-8dff-721798f77efc"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("49ca6967-22e2-4c79-9209-8734642faf7b"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("b7d7c5b5-c3f8-424e-ae90-c41bcb7cc2dd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18bc9f78-2859-4300-8dff-721798f77efc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("849c45bd-40db-4abc-8bdc-f7eaaa8d13d8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0b0e38f-6377-4f62-806a-a27602602070"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("18bc9f78-2859-4300-8dff-721798f77efc"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("849c45bd-40db-4abc-8bdc-f7eaaa8d13d8"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("a0b0e38f-6377-4f62-806a-a27602602070"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("248f6a5c-231e-48b5-9c9b-a137c0001758"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2c0571f6-3f8b-4da5-9494-36ae9179aa5d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc29b15d-32be-4959-91f4-da740dd72f6f"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("f8b697a6-f852-4f5e-9f0c-debb9975c816"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("248f6a5c-231e-48b5-9c9b-a137c0001758"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("2c0571f6-3f8b-4da5-9494-36ae9179aa5d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("fc29b15d-32be-4959-91f4-da740dd72f6f"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("47d63cac-5791-4797-859c-ab2e0cd7a96b"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("1d5d260b-8028-4b1e-a80d-66bdfb71e442"),
                    new Guid("23752845-42b6-4700-b7cf-9345234a0651"),
                    new Guid("2cb1a814-cd37-4ada-8595-a48a4c1b6bfb"),
                    new Guid("47d63cac-5791-4797-859c-ab2e0cd7a96b"),
                    new Guid("75ee1dca-f171-4eef-bb57-999c55f3da0b"),
                    new Guid("968d3d99-fa6a-49af-b094-a1d94f183d32"),
                    new Guid("99a598f7-4d31-4679-bc0a-d516e324aebd"),
                    new Guid("adec62d0-1a5c-4284-875a-602059f50add"),
                    new Guid("fd482647-c182-429f-9514-eedad9ce7997")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("99a598f7-4d31-4679-bc0a-d516e324aebd"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("23752845-42b6-4700-b7cf-9345234a0651"), "Employer" },
                    { new Guid("75ee1dca-f171-4eef-bb57-999c55f3da0b"), "Administrator" },
                    { new Guid("fd482647-c182-429f-9514-eedad9ce7997"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("adec62d0-1a5c-4284-875a-602059f50add"), new Guid("99a598f7-4d31-4679-bc0a-d516e324aebd"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("1d5d260b-8028-4b1e-a80d-66bdfb71e442"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("75ee1dca-f171-4eef-bb57-999c55f3da0b"), "Adminsky", "Akademicka", "Administator" },
                    { new Guid("2cb1a814-cd37-4ada-8595-a48a4c1b6bfb"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("fd482647-c182-429f-9514-eedad9ce7997"), "Karol", "Akademicka", "Pavulon" },
                    { new Guid("968d3d99-fa6a-49af-b094-a1d94f183d32"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("23752845-42b6-4700-b7cf-9345234a0651"), "Szef", "Akademicka", "Małysz" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("1d5d260b-8028-4b1e-a80d-66bdfb71e442"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("968d3d99-fa6a-49af-b094-a1d94f183d32"), new Guid("47d63cac-5791-4797-859c-ab2e0cd7a96b"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("2cb1a814-cd37-4ada-8595-a48a4c1b6bfb"), new Guid("adec62d0-1a5c-4284-875a-602059f50add") });
        }
    }
}
