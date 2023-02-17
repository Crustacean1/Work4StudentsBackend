using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class studentSchedulenotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "StartHour",
                table: "StudentSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "StudentSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "StudentSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "StartHour",
                table: "StudentSchedules",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "StudentSchedules",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "StudentSchedules",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
    }
}
