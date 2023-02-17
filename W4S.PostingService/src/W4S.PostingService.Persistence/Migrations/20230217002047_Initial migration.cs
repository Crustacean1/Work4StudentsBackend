using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "text", nullable: false),
                    AddressRegion = table.Column<string>(name: "Address_Region", type: "text", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "text", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "text", nullable: false),
                    AddressBuilding = table.Column<string>(name: "Address_Building", type: "text", nullable: false),
                    AddressLatitude = table.Column<double>(name: "Address_Latitude", type: "double precision", nullable: true),
                    AddressLongitude = table.Column<double>(name: "Address_Longitude", type: "double precision", nullable: true)
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
                    NIP = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants_Availability",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants_Availability", x => new { x.StudentId, x.Id });
                    table.ForeignKey(
                        name: "FK_Applicants_Availability_Applicants_StudentId",
                        column: x => x.StudentId,
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
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "text", nullable: false),
                    AddressRegion = table.Column<string>(name: "Address_Region", type: "text", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "text", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "text", nullable: false),
                    AddressBuilding = table.Column<string>(name: "Address_Building", type: "text", nullable: false),
                    AddressLatitude = table.Column<double>(name: "Address_Latitude", type: "double precision", nullable: true),
                    AddressLongitude = table.Column<double>(name: "Address_Longitude", type: "double precision", nullable: true)
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
                    Mode = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "text", nullable: false),
                    AddressRegion = table.Column<string>(name: "Address_Region", type: "text", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "text", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "text", nullable: false),
                    AddressBuilding = table.Column<string>(name: "Address_Building", type: "text", nullable: false),
                    AddressLatitude = table.Column<double>(name: "Address_Latitude", type: "double precision", nullable: true),
                    AddressLongitude = table.Column<double>(name: "Address_Longitude", type: "double precision", nullable: true),
                    PayRangeMin = table.Column<decimal>(name: "PayRange_Min", type: "numeric", nullable: false),
                    PayRangeMax = table.Column<decimal>(name: "PayRange_Max", type: "numeric", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Categories = table.Column<string>(type: "text", nullable: false),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false)
                        .Annotation("Npgsql:TsVectorConfig", "english")
                        .Annotation("Npgsql:TsVectorProperties", new[] { "Role", "Description", "Title" })
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
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkTimeOverlap = table.Column<double>(type: "double precision", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    LastChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Applicants_StudentId",
                        column: x => x.StudentId,
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

            migrationBuilder.CreateTable(
                name: "OfferReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecruiterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferReviews_Applicants_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferReviews_JobOffers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferReviews_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecruiterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationReviews_Applicants_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationReviews_Applicants_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationReviews_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationReviews_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("04ba9c77-4947-4a56-a478-25f39e91b736"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "Boilding", "Gliwice", "Polandia", null, null, "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("c75cae6e-77df-4445-9826-8b63ea51ecd5"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "Rating", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Latitude", "Address_Longitude", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("4e6f427e-4387-4845-bd4b-b56889b680c1"), new Guid("c75cae6e-77df-4445-9826-8b63ea51ecd5"), "noreply@company.et", "John", "123456789", 0.0m, "", "Smith", "24", "Gliwice", "Polandia", null, null, "Silesia", "Wrocławska" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviews_ApplicationId",
                table: "ApplicationReviews",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviews_RecruiterId",
                table: "ApplicationReviews",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviews_StudentId",
                table: "ApplicationReviews",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviews_StudentId1",
                table: "ApplicationReviews",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_OfferId",
                table: "Applications",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StudentId",
                table: "Applications",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_RecruiterId",
                table: "JobOffers",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_SearchVector",
                table: "JobOffers",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReviews_OfferId",
                table: "OfferReviews",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReviews_RecruiterId",
                table: "OfferReviews",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReviews_StudentId",
                table: "OfferReviews",
                column: "StudentId");

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
                name: "ApplicationReviews");

            migrationBuilder.DropTable(
                name: "JobOffers_WorkingHours");

            migrationBuilder.DropTable(
                name: "OfferReviews");

            migrationBuilder.DropTable(
                name: "Applications");

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
