using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudentSchedulesDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSchedule_StudentProfiles_StudentProfileId",
                table: "StudentSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSchedule",
                table: "StudentSchedule");

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

            migrationBuilder.RenameTable(
                name: "StudentSchedule",
                newName: "StudentSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSchedule_StudentProfileId",
                table: "StudentSchedules",
                newName: "IX_StudentSchedules_StudentProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSchedules",
                table: "StudentSchedules",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSchedules_StudentProfiles_StudentProfileId",
                table: "StudentSchedules",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSchedules_StudentProfiles_StudentProfileId",
                table: "StudentSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSchedules",
                table: "StudentSchedules");

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

            migrationBuilder.RenameTable(
                name: "StudentSchedules",
                newName: "StudentSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSchedules_StudentProfileId",
                table: "StudentSchedule",
                newName: "IX_StudentSchedule_StudentProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSchedule",
                table: "StudentSchedule",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSchedule_StudentProfiles_StudentProfileId",
                table: "StudentSchedule",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
