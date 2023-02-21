using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedpropertiestoprofiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("3c3ab5ea-9230-4c35-acac-dfba74865ee7"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("28e3fba5-6950-4ea6-af77-14f214ad5ac0"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("da7110ab-5dea-4bdf-b43a-5ba4df109ef0"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("e47ff4f4-1a4c-4959-9e79-107cfd6cff50"));

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
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("ac2200c2-b3e1-4ef9-bde7-6d77fa525f2b"));

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
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("0a49ca2b-deca-477e-b598-e1a1ce8cfd57"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("99a7e609-bc6e-4229-9c36-5fd413329a2d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("bad026f2-09aa-445d-b1bf-620ca9d48949"));

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

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("a6de2522-dd2b-4e16-a5c1-6a76dd1a5ab1"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("f0a976e5-4942-44a7-a4e5-bf1890ffda6d"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Profiles",
                newName: "PhotoFile");

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
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
                name: "PhoneNumber",
                table: "Profiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Profiles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Region",
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

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "EmployerProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PositionName",
                table: "EmployerProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Building",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Building",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "EmployerProfiles");

            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "EmployerProfiles");

            migrationBuilder.RenameColumn(
                name: "PhotoFile",
                table: "Profiles",
                newName: "Image");

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "StudentProfiles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

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
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingValue = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings",
                column: "StudentId");
        }
    }
}
