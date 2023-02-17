using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedstudentSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("bdb73133-143e-4b60-bb61-b0b882e38c21"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("70b8cf78-0c0e-40d8-be86-6ace64a412a4"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("4660f431-b1b7-4c83-a883-5730fa1508cf"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("70b8cf78-0c0e-40d8-be86-6ace64a412a4"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("773044e1-3f0e-4ee3-b825-378ffd8c0963"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5f39fa5e-730d-416d-aad2-3c3a0f6db412"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("80e91afd-22f2-4571-a3eb-b9891daf9c08"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("773044e1-3f0e-4ee3-b825-378ffd8c0963"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("5f39fa5e-730d-416d-aad2-3c3a0f6db412"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("80e91afd-22f2-4571-a3eb-b9891daf9c08"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("4660f431-b1b7-4c83-a883-5730fa1508cf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bdb73133-143e-4b60-bb61-b0b882e38c21"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("bdb73133-143e-4b60-bb61-b0b882e38c21"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b1bda1a8-4d8c-4f1a-b056-3bd5b34dfc07"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("b1bda1a8-4d8c-4f1a-b056-3bd5b34dfc07"));

            migrationBuilder.DropColumn(
                name: "End",
                table: "StudentSchedules");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "StudentSchedules");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "StudentSchedules",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "StudentSchedules",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartHour",
                table: "StudentSchedules",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("cdb88ab0-4d60-4fde-9f77-7a63f9d125ed"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("57337d67-9f1e-4c0e-a47d-9c5cd218ea24"),
                    new Guid("5c2cfe27-c447-4ae7-98b5-de1499acf281"),
                    new Guid("7d9cfbec-422f-4ee7-9626-d82e6b91f175"),
                    new Guid("90890912-610a-46c5-9f75-6dffeca27559"),
                    new Guid("a14c7b26-2881-424a-bc1a-449f11279dbb"),
                    new Guid("cdb88ab0-4d60-4fde-9f77-7a63f9d125ed"),
                    new Guid("f5d0406a-0974-4d6f-8b60-1576cd3f89e1")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("90890912-610a-46c5-9f75-6dffeca27559"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("7d9cfbec-422f-4ee7-9626-d82e6b91f175"), "Administrator" },
                    { new Guid("a14c7b26-2881-424a-bc1a-449f11279dbb"), "Employer" },
                    { new Guid("f5d0406a-0974-4d6f-8b60-1576cd3f89e1"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("57337d67-9f1e-4c0e-a47d-9c5cd218ea24"), new Guid("90890912-610a-46c5-9f75-6dffeca27559"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[] { new Guid("5c2cfe27-c447-4ae7-98b5-de1499acf281"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("7d9cfbec-422f-4ee7-9626-d82e6b91f175"), "Adminsky", "Akademicka", "Administator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("5c2cfe27-c447-4ae7-98b5-de1499acf281"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("5c2cfe27-c447-4ae7-98b5-de1499acf281"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("cdb88ab0-4d60-4fde-9f77-7a63f9d125ed"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("57337d67-9f1e-4c0e-a47d-9c5cd218ea24"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("90890912-610a-46c5-9f75-6dffeca27559"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("cdb88ab0-4d60-4fde-9f77-7a63f9d125ed"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a14c7b26-2881-424a-bc1a-449f11279dbb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f5d0406a-0974-4d6f-8b60-1576cd3f89e1"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("57337d67-9f1e-4c0e-a47d-9c5cd218ea24"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("a14c7b26-2881-424a-bc1a-449f11279dbb"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("f5d0406a-0974-4d6f-8b60-1576cd3f89e1"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("90890912-610a-46c5-9f75-6dffeca27559"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c2cfe27-c447-4ae7-98b5-de1499acf281"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("5c2cfe27-c447-4ae7-98b5-de1499acf281"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d9cfbec-422f-4ee7-9626-d82e6b91f175"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7d9cfbec-422f-4ee7-9626-d82e6b91f175"));

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "StudentSchedules");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "StudentSchedules");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "StudentSchedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "StudentSchedules",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "StudentSchedules",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("70b8cf78-0c0e-40d8-be86-6ace64a412a4"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("4660f431-b1b7-4c83-a883-5730fa1508cf"),
                    new Guid("5f39fa5e-730d-416d-aad2-3c3a0f6db412"),
                    new Guid("70b8cf78-0c0e-40d8-be86-6ace64a412a4"),
                    new Guid("773044e1-3f0e-4ee3-b825-378ffd8c0963"),
                    new Guid("80e91afd-22f2-4571-a3eb-b9891daf9c08"),
                    new Guid("b1bda1a8-4d8c-4f1a-b056-3bd5b34dfc07"),
                    new Guid("bdb73133-143e-4b60-bb61-b0b882e38c21")
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("4660f431-b1b7-4c83-a883-5730fa1508cf"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("5f39fa5e-730d-416d-aad2-3c3a0f6db412"), "Employer" },
                    { new Guid("80e91afd-22f2-4571-a3eb-b9891daf9c08"), "Student" },
                    { new Guid("b1bda1a8-4d8c-4f1a-b056-3bd5b34dfc07"), "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("773044e1-3f0e-4ee3-b825-378ffd8c0963"), new Guid("4660f431-b1b7-4c83-a883-5730fa1508cf"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[] { new Guid("bdb73133-143e-4b60-bb61-b0b882e38c21"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("b1bda1a8-4d8c-4f1a-b056-3bd5b34dfc07"), "Adminsky", "Akademicka", "Administator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("bdb73133-143e-4b60-bb61-b0b882e38c21"));
        }
    }
}
