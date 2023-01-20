using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedprofiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("94be9e1e-aa78-4329-b07e-c045801ebd7e"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("3c60b300-32a0-49d3-8b6b-9aa629d14cac"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ee1f732a-2b7c-46a7-b198-d62887e388a0"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8ccac33d-768d-4ae3-9749-a9f756471234"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("b133cb75-8968-4844-9b1a-568f3d642d81"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c60b300-32a0-49d3-8b6b-9aa629d14cac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94be9e1e-aa78-4329-b07e-c045801ebd7e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee1f732a-2b7c-46a7-b198-d62887e388a0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("318d3ea9-f9fa-4c88-bd4f-5437f283a6aa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4e50b4cc-ca26-411f-8fc9-9c8429af0457"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("60a5ce7b-fc37-4f7b-ad7e-50780509002d"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("335587c9-9bfd-4517-a506-5541425636f6"));

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", maxLength: 5242880, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployerProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerProfiles_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployerProfiles_Profiles_Id",
                        column: x => x.Id,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ResumeFile = table.Column<byte[]>(type: "bytea", maxLength: 5242880, nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_Profiles_Id",
                        column: x => x.Id,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("9bce4996-9c89-41d5-a3eb-0762e283ca8c"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Description", "Image" },
                values: new object[,]
                {
                    { new Guid("2b52c383-f325-4c79-a5b8-4ae5deef633d"), "My company is the best.", new byte[] { 0, 0, 0, 0 } },
                    { new Guid("f641e682-2289-4a79-9b21-dfe4417a234d"), "My university is the best.", new byte[] { 0, 0, 0, 0 } }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("3a930519-5abd-475c-8eb7-23c362110a4a"), "Student" },
                    { new Guid("c97beb63-6cdc-4e71-ad50-d18216c65a0a"), "Administrator" },
                    { new Guid("ebf8d68e-6e46-4e0e-873a-a6f773a0f70f"), "Employer" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("cec91182-5735-4c4b-97d3-0e3952dec725"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("0c0ca869-7e0d-4482-b09d-776d3646b1c3"), new Guid("cec91182-5735-4c4b-97d3-0e3952dec725"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "RoleId", "SecondName", "Surname" },
                values: new object[,]
                {
                    { new Guid("3da3094f-0506-4688-b761-9f91041b3af7"), "student.debil@polsl.pl", "John", "61646d696e", "+2137", new Guid("3a930519-5abd-475c-8eb7-23c362110a4a"), "Karol", "Pavulon" },
                    { new Guid("bf4b8d86-f654-41b8-993d-32c0fa502ada"), "someEmployer@gmail.com", "Adam", "61646d696e", "2137", new Guid("ebf8d68e-6e46-4e0e-873a-a6f773a0f70f"), "Szef", "Małysz" },
                    { new Guid("fe5cf869-1c56-42b8-952b-afc687ce1b14"), "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", new Guid("c97beb63-6cdc-4e71-ad50-d18216c65a0a"), "Adminsky", "Administator" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("fe5cf869-1c56-42b8-952b-afc687ce1b14"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("bf4b8d86-f654-41b8-993d-32c0fa502ada"), new Guid("9bce4996-9c89-41d5-a3eb-0762e283ca8c"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("3da3094f-0506-4688-b761-9f91041b3af7"), new Guid("0c0ca869-7e0d-4482-b09d-776d3646b1c3") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "EmployerId" },
                values: new object[] { new Guid("2b52c383-f325-4c79-a5b8-4ae5deef633d"), new Guid("bf4b8d86-f654-41b8-993d-32c0fa502ada") });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("f641e682-2289-4a79-9b21-dfe4417a234d"), null, new Guid("3da3094f-0506-4688-b761-9f91041b3af7") });

            migrationBuilder.CreateIndex(
                name: "IX_EmployerProfiles_EmployerId",
                table: "EmployerProfiles",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_StudentId",
                table: "StudentProfiles",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerProfiles");

            migrationBuilder.DropTable(
                name: "StudentProfiles");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("fe5cf869-1c56-42b8-952b-afc687ce1b14"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("bf4b8d86-f654-41b8-993d-32c0fa502ada"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3da3094f-0506-4688-b761-9f91041b3af7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9bce4996-9c89-41d5-a3eb-0762e283ca8c"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("0c0ca869-7e0d-4482-b09d-776d3646b1c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3da3094f-0506-4688-b761-9f91041b3af7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf4b8d86-f654-41b8-993d-32c0fa502ada"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe5cf869-1c56-42b8-952b-afc687ce1b14"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3a930519-5abd-475c-8eb7-23c362110a4a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c97beb63-6cdc-4e71-ad50-d18216c65a0a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ebf8d68e-6e46-4e0e-873a-a6f773a0f70f"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("cec91182-5735-4c4b-97d3-0e3952dec725"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("8ccac33d-768d-4ae3-9749-a9f756471234"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("318d3ea9-f9fa-4c88-bd4f-5437f283a6aa"), "Administrator" },
                    { new Guid("4e50b4cc-ca26-411f-8fc9-9c8429af0457"), "Student" },
                    { new Guid("60a5ce7b-fc37-4f7b-ad7e-50780509002d"), "Employer" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("335587c9-9bfd-4517-a506-5541425636f6"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("b133cb75-8968-4844-9b1a-568f3d642d81"), new Guid("335587c9-9bfd-4517-a506-5541425636f6"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "RoleId", "SecondName", "Surname" },
                values: new object[,]
                {
                    { new Guid("3c60b300-32a0-49d3-8b6b-9aa629d14cac"), "someEmployer@gmail.com", "Adam", "61646d696e", "2137", new Guid("60a5ce7b-fc37-4f7b-ad7e-50780509002d"), "Szef", "Małysz" },
                    { new Guid("94be9e1e-aa78-4329-b07e-c045801ebd7e"), "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", new Guid("318d3ea9-f9fa-4c88-bd4f-5437f283a6aa"), "Adminsky", "Administator" },
                    { new Guid("ee1f732a-2b7c-46a7-b198-d62887e388a0"), "student.debil@polsl.pl", "John", "61646d696e", "+2137", new Guid("4e50b4cc-ca26-411f-8fc9-9c8429af0457"), "Karol", "Pavulon" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("94be9e1e-aa78-4329-b07e-c045801ebd7e"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("3c60b300-32a0-49d3-8b6b-9aa629d14cac"), new Guid("8ccac33d-768d-4ae3-9749-a9f756471234"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("ee1f732a-2b7c-46a7-b198-d62887e388a0"), new Guid("b133cb75-8968-4844-9b1a-568f3d642d81") });
        }
    }
}
