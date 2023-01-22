using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedbaseEntitycompanyProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("ba732c8d-ae8c-4854-accb-ecaf2d5d564d"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("4c7d5766-63b9-47ef-bd0a-5a34a68d3648"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("d61ac36a-f3dd-42a6-9541-fa2d011b8b40"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("81487f7c-1ce3-4a2a-b5ea-586185c99348"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("4c7d5766-63b9-47ef-bd0a-5a34a68d3648"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d61ac36a-f3dd-42a6-9541-fa2d011b8b40"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("17dc81ea-d11f-4b32-b0b9-a506aeacb92a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ba732c8d-ae8c-4854-accb-ecaf2d5d564d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2b847e27-2544-4acf-8863-7b549b597d3d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("025c54ee-8981-4d45-aa39-926dff90b3ed"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("92004ea7-fd0f-48d4-89f3-599202b3ac08"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("17dc81ea-d11f-4b32-b0b9-a506aeacb92a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("81487f7c-1ce3-4a2a-b5ea-586185c99348"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0e5464e2-77ae-437f-a803-231cd94c87e2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("40cd69f9-93a9-43dd-912d-36d7f9f4fa0c"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("ee0a46c2-829b-411c-9dfe-3e0abf4d6685"));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "Profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"),
                    new Guid("28e3fba5-6950-4ea6-af77-14f214ad5ac0"),
                    new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"),
                    new Guid("a6de2522-dd2b-4e16-a5c1-6a76dd1a5ab1"),
                    new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"),
                    new Guid("bad026f2-09aa-445d-b1bf-620ca9d48949"),
                    new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"),
                    new Guid("e47ff4f4-1a4c-4959-9e79-107cfd6cff50"),
                    new Guid("f0a976e5-4942-44a7-a4e5-bf1890ffda6d")
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Description", "EntityId", "Image" },
                values: new object[,]
                {
                    { new Guid("3c3ab5ea-9230-4c35-acac-dfba74865ee7"), "My company is the best.", new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"), new byte[] { 0, 0, 0, 0 } },
                    { new Guid("b62ba221-2f57-4c58-920a-08d1e7def693"), "My university is the best.", new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"), new byte[] { 0, 0, 0, 0 } },
                    { new Guid("d3b15d3c-f906-47d5-b9d3-d14de7f9454c"), "Greatest company there is.", new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"), new byte[] { 0, 0, 0, 0 } }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("28e3fba5-6950-4ea6-af77-14f214ad5ac0"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "CompanyProfiles",
                columns: new[] { "Id", "CompanyId" },
                values: new object[] { new Guid("d3b15d3c-f906-47d5-b9d3-d14de7f9454c"), new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("a6de2522-dd2b-4e16-a5c1-6a76dd1a5ab1"), "Employer" },
                    { new Guid("bad026f2-09aa-445d-b1bf-620ca9d48949"), "Administrator" },
                    { new Guid("f0a976e5-4942-44a7-a4e5-bf1890ffda6d"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("e47ff4f4-1a4c-4959-9e79-107cfd6cff50"), new Guid("28e3fba5-6950-4ea6-af77-14f214ad5ac0"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "RoleId", "SecondName", "Surname" },
                values: new object[,]
                {
                    { new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"), "student.debil@polsl.pl", "John", "61646d696e", "+2137", new Guid("f0a976e5-4942-44a7-a4e5-bf1890ffda6d"), "Karol", "Pavulon" },
                    { new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"), "someEmployer@gmail.com", "Adam", "61646d696e", "2137", new Guid("a6de2522-dd2b-4e16-a5c1-6a76dd1a5ab1"), "Szef", "Małysz" },
                    { new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"), "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", new Guid("bad026f2-09aa-445d-b1bf-620ca9d48949"), "Adminsky", "Administator" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"), new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"), new Guid("e47ff4f4-1a4c-4959-9e79-107cfd6cff50") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "EmployerId" },
                values: new object[] { new Guid("3c3ab5ea-9230-4c35-acac-dfba74865ee7"), new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d") });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "Rating", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("b62ba221-2f57-4c58-920a-08d1e7def693"), 0m, null, new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57") });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_CompanyId",
                table: "CompanyProfiles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Entities_Id",
                table: "Roles",
                column: "Id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Entities_Id",
                table: "Users",
                column: "Id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Entities_Id",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Entities_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("3c3ab5ea-9230-4c35-acac-dfba74865ee7"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d3b15d3c-f906-47d5-b9d3-d14de7f9454c"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("b62ba221-2f57-4c58-920a-08d1e7def693"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("3c3ab5ea-9230-4c35-acac-dfba74865ee7"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b62ba221-2f57-4c58-920a-08d1e7def693"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bad026f2-09aa-445d-b1bf-620ca9d48949"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("e47ff4f4-1a4c-4959-9e79-107cfd6cff50"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a6de2522-dd2b-4e16-a5c1-6a76dd1a5ab1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0a976e5-4942-44a7-a4e5-bf1890ffda6d"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("28e3fba5-6950-4ea6-af77-14f214ad5ac0"));

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Profiles");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("2b847e27-2544-4acf-8863-7b549b597d3d"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Description", "Image" },
                values: new object[,]
                {
                    { new Guid("4c7d5766-63b9-47ef-bd0a-5a34a68d3648"), "My company is the best.", new byte[] { 0, 0, 0, 0 } },
                    { new Guid("d61ac36a-f3dd-42a6-9541-fa2d011b8b40"), "My university is the best.", new byte[] { 0, 0, 0, 0 } }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("025c54ee-8981-4d45-aa39-926dff90b3ed"), "Administrator" },
                    { new Guid("0e5464e2-77ae-437f-a803-231cd94c87e2"), "Employer" },
                    { new Guid("40cd69f9-93a9-43dd-912d-36d7f9f4fa0c"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("ee0a46c2-829b-411c-9dfe-3e0abf4d6685"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("92004ea7-fd0f-48d4-89f3-599202b3ac08"), new Guid("ee0a46c2-829b-411c-9dfe-3e0abf4d6685"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "RoleId", "SecondName", "Surname" },
                values: new object[,]
                {
                    { new Guid("17dc81ea-d11f-4b32-b0b9-a506aeacb92a"), "student.debil@polsl.pl", "John", "61646d696e", "+2137", new Guid("40cd69f9-93a9-43dd-912d-36d7f9f4fa0c"), "Karol", "Pavulon" },
                    { new Guid("81487f7c-1ce3-4a2a-b5ea-586185c99348"), "someEmployer@gmail.com", "Adam", "61646d696e", "2137", new Guid("0e5464e2-77ae-437f-a803-231cd94c87e2"), "Szef", "Małysz" },
                    { new Guid("ba732c8d-ae8c-4854-accb-ecaf2d5d564d"), "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", new Guid("025c54ee-8981-4d45-aa39-926dff90b3ed"), "Adminsky", "Administator" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("ba732c8d-ae8c-4854-accb-ecaf2d5d564d"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("81487f7c-1ce3-4a2a-b5ea-586185c99348"), new Guid("2b847e27-2544-4acf-8863-7b549b597d3d"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("17dc81ea-d11f-4b32-b0b9-a506aeacb92a"), new Guid("92004ea7-fd0f-48d4-89f3-599202b3ac08") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "EmployerId" },
                values: new object[] { new Guid("4c7d5766-63b9-47ef-bd0a-5a34a68d3648"), new Guid("81487f7c-1ce3-4a2a-b5ea-586185c99348") });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "Rating", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("d61ac36a-f3dd-42a6-9541-fa2d011b8b40"), 0m, null, new Guid("17dc81ea-d11f-4b32-b0b9-a506aeacb92a") });
        }
    }
}
