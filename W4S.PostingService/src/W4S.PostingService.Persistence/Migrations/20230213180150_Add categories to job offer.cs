using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4S.PostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addcategoriestojoboffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("e49f7268-2dd6-4f4b-9709-c828373ae6b7"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("935b10a7-f02d-4e8e-a9e6-729f3e38afe7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"));

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "JobOffers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JobOfferId = table.Column<Guid>(type: "uuid", nullable: true),
                    RecruiterId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Applicants_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Applicants_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_JobOffers_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("6203e242-4cc5-419c-a9b8-ae4cc30334aa"), "noreply@company.et", "John", "123456789", null, "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("82e51216-4e81-4c7a-93aa-a3eafa4695ad"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname" },
                values: new object[] { new Guid("4fa5c5d3-de0a-469b-af99-81c6ac31baf5"), new Guid("82e51216-4e81-4c7a-93aa-a3eafa4695ad"), "noreply@company.et", "John", "123456789", null, "Smith" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_JobOfferId",
                table: "Reviews",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecruiterId",
                table: "Reviews",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentId",
                table: "Reviews",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentId1",
                table: "Reviews",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SubjectId",
                table: "Reviews",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: new Guid("6203e242-4cc5-419c-a9b8-ae4cc30334aa"));

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: new Guid("4fa5c5d3-de0a-469b-af99-81c6ac31baf5"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("82e51216-4e81-4c7a-93aa-a3eafa4695ad"));

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "JobOffers");

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname", "Address_Building", "Address_City", "Address_Country", "Address_Region", "Address_Street" },
                values: new object[] { new Guid("e49f7268-2dd6-4f4b-9709-c828373ae6b7"), "noreply@company.et", "John", "123456789", null, "Smith", "Boilding", "Gliwice", "Polandia", "Silesia", "Street" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"), "7821160955", "Comarch" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstName", "PhoneNumber", "SecondName", "Surname" },
                values: new object[] { new Guid("935b10a7-f02d-4e8e-a9e6-729f3e38afe7"), new Guid("8db7c987-8a09-4904-9c95-bda5dfe55f2f"), "noreply@company.et", "John", "123456789", null, "Smith" });
        }
    }
}
