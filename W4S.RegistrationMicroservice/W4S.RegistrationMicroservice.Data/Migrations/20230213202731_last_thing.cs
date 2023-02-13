using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class lastthing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("b6afffc0-a64c-46b4-80af-47a0c44bbd4e"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("003d5153-bac5-45fd-b5db-408867e7bf6c"),
                    new Guid("0645b4a7-9592-421a-b0b5-fadd36494114"),
                    new Guid("163985c8-3c69-45c8-b28b-d0adc2d95bd3"),
                    new Guid("1ec4373e-bdde-4c6a-b74f-f74c4abafffc"),
                    new Guid("382ff617-1899-46b2-94da-ae766465d6e0"),
                    new Guid("69023621-9744-493e-91f0-e7958a52c2f8"),
                    new Guid("9fdf2b41-adb4-45cd-8caa-2466022d4566"),
                    new Guid("afd4789a-e7df-436a-ba24-6d1f3a3a86f8"),
                    new Guid("b6afffc0-a64c-46b4-80af-47a0c44bbd4e")
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Building", "City", "Country", "Description", "Education", "EmailAddress", "Experience", "PhoneNumber", "PhotoFile", "Rating", "Region", "ShortDescription", "Street" },
                values: new object[,]
                {
                    { new Guid("4adc6ddc-88dc-448a-859c-4d2e9dfacd3d"), "2a", "Gliwice", "Poland", "My company is the best.", "Bachelor in Milfology", "someEmployer@gmail.com", "5 years as Milfhunter", "2137", null, 0.0m, "Silesia", "My company...", "Akademicka" },
                    { new Guid("b35d8b44-486c-45b3-ac13-e0090a5f4256"), "2a", "Gliwice", "Poland", "My university is the best.", "Silesian University of Science, Informatics", "someEmployer@gmail.com", "20 years in Unity", "+2137", null, 0.0m, "Silesia", "My university...", "Akademicka" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("afd4789a-e7df-436a-ba24-6d1f3a3a86f8"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("0645b4a7-9592-421a-b0b5-fadd36494114"), "Student" },
                    { new Guid("69023621-9744-493e-91f0-e7958a52c2f8"), "Administrator" },
                    { new Guid("9fdf2b41-adb4-45cd-8caa-2466022d4566"), "Employer" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("003d5153-bac5-45fd-b5db-408867e7bf6c"), new Guid("afd4789a-e7df-436a-ba24-6d1f3a3a86f8"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("163985c8-3c69-45c8-b28b-d0adc2d95bd3"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("0645b4a7-9592-421a-b0b5-fadd36494114"), "Karol", "Akademicka", "Pavulon" },
                    { new Guid("1ec4373e-bdde-4c6a-b74f-f74c4abafffc"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("69023621-9744-493e-91f0-e7958a52c2f8"), "Adminsky", "Akademicka", "Administator" },
                    { new Guid("382ff617-1899-46b2-94da-ae766465d6e0"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("9fdf2b41-adb4-45cd-8caa-2466022d4566"), "Szef", "Akademicka", "Małysz" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("1ec4373e-bdde-4c6a-b74f-f74c4abafffc"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("382ff617-1899-46b2-94da-ae766465d6e0"), new Guid("b6afffc0-a64c-46b4-80af-47a0c44bbd4e"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("163985c8-3c69-45c8-b28b-d0adc2d95bd3"), new Guid("003d5153-bac5-45fd-b5db-408867e7bf6c") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "CompanyName", "EmployerId", "PositionName" },
                values: new object[] { new Guid("4adc6ddc-88dc-448a-859c-4d2e9dfacd3d"), "Empty firm in Poland", new Guid("382ff617-1899-46b2-94da-ae766465d6e0"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("b35d8b44-486c-45b3-ac13-e0090a5f4256"), null, new Guid("163985c8-3c69-45c8-b28b-d0adc2d95bd3") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("1ec4373e-bdde-4c6a-b74f-f74c4abafffc"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("4adc6ddc-88dc-448a-859c-4d2e9dfacd3d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("003d5153-bac5-45fd-b5db-408867e7bf6c"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("afd4789a-e7df-436a-ba24-6d1f3a3a86f8"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("b6afffc0-a64c-46b4-80af-47a0c44bbd4e"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("b35d8b44-486c-45b3-ac13-e0090a5f4256"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("382ff617-1899-46b2-94da-ae766465d6e0"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("4adc6ddc-88dc-448a-859c-4d2e9dfacd3d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b35d8b44-486c-45b3-ac13-e0090a5f4256"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("163985c8-3c69-45c8-b28b-d0adc2d95bd3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ec4373e-bdde-4c6a-b74f-f74c4abafffc"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("b6afffc0-a64c-46b4-80af-47a0c44bbd4e"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1ec4373e-bdde-4c6a-b74f-f74c4abafffc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69023621-9744-493e-91f0-e7958a52c2f8"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("003d5153-bac5-45fd-b5db-408867e7bf6c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("163985c8-3c69-45c8-b28b-d0adc2d95bd3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("382ff617-1899-46b2-94da-ae766465d6e0"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("163985c8-3c69-45c8-b28b-d0adc2d95bd3"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("382ff617-1899-46b2-94da-ae766465d6e0"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("69023621-9744-493e-91f0-e7958a52c2f8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0645b4a7-9592-421a-b0b5-fadd36494114"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9fdf2b41-adb4-45cd-8caa-2466022d4566"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("afd4789a-e7df-436a-ba24-6d1f3a3a86f8"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("0645b4a7-9592-421a-b0b5-fadd36494114"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("9fdf2b41-adb4-45cd-8caa-2466022d4566"));

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
    }
}
