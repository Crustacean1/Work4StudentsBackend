using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedratings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("fe5cf869-1c56-42b8-952b-afc687ce1b14"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("2b52c383-f325-4c79-a5b8-4ae5deef633d"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("f641e682-2289-4a79-9b21-dfe4417a234d"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("bf4b8d86-f654-41b8-993d-32c0fa502ada"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2b52c383-f325-4c79-a5b8-4ae5deef633d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("f641e682-2289-4a79-9b21-dfe4417a234d"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3da3094f-0506-4688-b761-9f91041b3af7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe5cf869-1c56-42b8-952b-afc687ce1b14"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9bce4996-9c89-41d5-a3eb-0762e283ca8c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c97beb63-6cdc-4e71-ad50-d18216c65a0a"));

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
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3a930519-5abd-475c-8eb7-23c362110a4a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ebf8d68e-6e46-4e0e-873a-a6f773a0f70f"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("cec91182-5735-4c4b-97d3-0e3952dec725"));

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "StudentProfiles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingValue = table.Column<decimal>(type: "numeric", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

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

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "StudentProfiles");

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
        }
    }
}
