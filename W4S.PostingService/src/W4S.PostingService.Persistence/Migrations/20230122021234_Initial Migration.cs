using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "text", nullable: false),
                    AddressRegion = table.Column<string>(name: "Address_Region", type: "text", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "text", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "text", nullable: false),
                    AddressBuilding = table.Column<string>(name: "Address_Building", type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "text", nullable: false),
                    AddressRegion = table.Column<string>(name: "Address_Region", type: "text", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "text", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "text", nullable: false),
                    AddressBuilding = table.Column<string>(name: "Address_Building", type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants_Availability",
                columns: table => new
                {
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants_Availability", x => new { x.ApplicantId, x.Id });
                    table.ForeignKey(
                        name: "FK_Applicants_Availability_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recruiters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruiters_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecruiterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "text", nullable: false),
                    AddressRegion = table.Column<string>(name: "Address_Region", type: "text", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "text", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "text", nullable: false),
                    AddressBuilding = table.Column<string>(name: "Address_Building", type: "text", nullable: false),
                    Openings = table.Column<long>(type: "bigint", nullable: false),
                    PayRangeMin = table.Column<decimal>(name: "PayRange_Min", type: "numeric", nullable: false),
                    PayRangeMax = table.Column<decimal>(name: "PayRange_Max", type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkTimeOverlap = table.Column<decimal>(type: "numeric", nullable: false),
                    Proximity = table.Column<decimal>(type: "numeric", nullable: false),
                    LastChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_JobOffers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers_WorkingHours",
                columns: table => new
                {
                    JobOfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers_WorkingHours", x => new { x.JobOfferId, x.Id });
                    table.ForeignKey(
                        name: "FK_JobOffers_WorkingHours_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "Email", "FirstName", "PhoneNumber", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("84970053-0cdb-4438-8812-7a4a581b2452"), "noreply@company.et", "John", "123456789", "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("2badd62b-ddd2-4f46-9a5b-3f8f37c91ea8"), "It is what it is", "Company", "Macdonald", "Gliwice", "Poland", "Silesia", "Wrocławska" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "PhoneNumber", "Surname" },
                values: new object[] { new Guid("815a4216-3e5b-4b84-9afc-ff099763fd59"), new Guid("2badd62b-ddd2-4f46-9a5b-3f8f37c91ea8"), "noreply@company.et", "John", "123456789", "Smith" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantId",
                table: "Applications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_OfferId",
                table: "Applications",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_RecruiterId",
                table: "JobOffers",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_CompanyId",
                table: "Recruiters",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants_Availability");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "JobOffers_WorkingHours");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Recruiters");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
