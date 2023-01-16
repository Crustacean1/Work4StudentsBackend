using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NIP = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversitiesDomains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailDomain = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversitiesDomains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmailDomainId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universities_UniversitiesDomains_EmailDomainId",
                        column: x => x.EmailDomainId,
                        principalTable: "UniversitiesDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionName = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("50543f72-294b-4a85-b45e-613f85a39a48"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("26c8d022-b1da-4a48-8e9c-81b39c95f22e"), "Administrator" },
                    { new Guid("86b206da-db92-4ae2-b8b1-8bb551482f3b"), "Administrator" },
                    { new Guid("cb90ce28-101d-45c5-bdd3-419c13d49b01"), "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("476e3e6f-265d-4d3c-8c10-03830f745732"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("d6700711-6103-4b56-a108-419ee205ea80"), new Guid("476e3e6f-265d-4d3c-8c10-03830f745732"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "RoleId", "SecondName", "Surname" },
                values: new object[,]
                {
                    { new Guid("17e08779-c16e-4e25-8caf-fe466e4eb428"), "student.debil@polsl.pl", "John", "61646d696e", "+2137", new Guid("cb90ce28-101d-45c5-bdd3-419c13d49b01"), "Karol", "Pavulon" },
                    { new Guid("881ee53f-2d9b-41fd-96f1-bc01c67c4f76"), "someEmployer@gmail.com", "Adam", "4e4f544841534845443a444444", "2137", new Guid("26c8d022-b1da-4a48-8e9c-81b39c95f22e"), "Szef", "Małysz" },
                    { new Guid("d9d27168-3012-4679-b3e9-818f76aa708a"), "someEmployer@gmail.com", "Adam", "4e4f544841534845443a444444", "2137", new Guid("86b206da-db92-4ae2-b8b1-8bb551482f3b"), "Szef", "Małysz" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("d9d27168-3012-4679-b3e9-818f76aa708a"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("881ee53f-2d9b-41fd-96f1-bc01c67c4f76"), new Guid("50543f72-294b-4a85-b45e-613f85a39a48"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("17e08779-c16e-4e25-8caf-fe466e4eb428"), new Guid("d6700711-6103-4b56-a108-419ee205ea80") });

            migrationBuilder.CreateIndex(
                name: "IX_Employers_CompanyId",
                table: "Employers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityId",
                table: "Students",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_EmailDomainId",
                table: "Universities",
                column: "EmailDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UniversitiesDomains");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
