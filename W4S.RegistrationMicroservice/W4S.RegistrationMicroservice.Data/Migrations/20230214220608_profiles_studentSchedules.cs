using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W4S.RegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class profilesstudentSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("6f3e94e5-ec62-45b9-b3d5-02411c534b8c"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("4fc77265-561e-4121-ad6d-e3d295e73815"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("ac14e6fa-71a7-4e91-9697-30aa383cc6c0"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("e6204f75-d6a0-4473-8b94-cf950beb1640"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("f47e73e8-fe8e-49fd-86a6-e8deab775bd0"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("0cabe4a6-c279-477f-8d0d-83ea66b66f3d"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("f8b26051-f58a-4a1c-872c-be7c008ca0c8"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("0cabe4a6-c279-477f-8d0d-83ea66b66f3d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("4fc77265-561e-4121-ad6d-e3d295e73815"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3d46c8b0-d594-40e3-bb74-3826bebd485f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f3e94e5-ec62-45b9-b3d5-02411c534b8c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("ac14e6fa-71a7-4e91-9697-30aa383cc6c0"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("6f3e94e5-ec62-45b9-b3d5-02411c534b8c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c8275cb0-4793-48eb-a2bf-7fe174c72a2c"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("f47e73e8-fe8e-49fd-86a6-e8deab775bd0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d46c8b0-d594-40e3-bb74-3826bebd485f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8b26051-f58a-4a1c-872c-be7c008ca0c8"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("3d46c8b0-d594-40e3-bb74-3826bebd485f"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("c8275cb0-4793-48eb-a2bf-7fe174c72a2c"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("f8b26051-f58a-4a1c-872c-be7c008ca0c8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0ff3793a-1be0-425f-bdba-0d6fbb47ddab"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4daa42e3-ec8d-474e-9df3-e677515b294a"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("e6204f75-d6a0-4473-8b94-cf950beb1640"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("0ff3793a-1be0-425f-bdba-0d6fbb47ddab"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("4daa42e3-ec8d-474e-9df3-e677515b294a"));

            migrationBuilder.CreateTable(
                name: "StudentSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentProfileId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSchedule_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"),
                    new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"),
                    new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"),
                    new Guid("52d5f876-7f6d-4441-989a-d509973f829d"),
                    new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"),
                    new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"),
                    new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"),
                    new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"),
                    new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554")
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Building", "City", "Country", "Description", "Education", "EmailAddress", "Experience", "PhoneNumber", "PhotoFile", "Rating", "Region", "ShortDescription", "Street" },
                values: new object[,]
                {
                    { new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"), "2a", "Gliwice", "Poland", "My company is the best.", "Bachelor in Milfology", "someEmployer@gmail.com", "5 years as Milfhunter", "2137", null, 0.0m, "Silesia", "My company...", "Akademicka" },
                    { new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"), "2a", "Gliwice", "Poland", "My university is the best.", "Silesian University of Science, Informatics", "someEmployer@gmail.com", "20 years in Unity", "+2137", null, 0.0m, "Silesia", "My university...", "Akademicka" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"), "Student" },
                    { new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"), "Administrator" },
                    { new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"), "Employer" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"), new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"), "Adminsky", "Akademicka", "Administator" },
                    { new Guid("52d5f876-7f6d-4441-989a-d509973f829d"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"), "Szef", "Akademicka", "Małysz" },
                    { new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"), "Karol", "Akademicka", "Pavulon" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("52d5f876-7f6d-4441-989a-d509973f829d"), new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"), new Guid("7172c284-148e-49c6-940e-0cecf7f9e512") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "CompanyName", "EmployerId", "PositionName" },
                values: new object[] { new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"), "Empty firm in Poland", new Guid("52d5f876-7f6d-4441-989a-d509973f829d"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"), null, new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5") });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchedule_StudentProfileId",
                table: "StudentSchedule",
                column: "StudentProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSchedule");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.DeleteData(
                table: "EmployerProfiles",
                keyColumn: "Id",
                keyValue: new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"));

            migrationBuilder.DeleteData(
                table: "StudentProfiles",
                keyColumn: "Id",
                keyValue: new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"));

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("52d5f876-7f6d-4441-989a-d509973f829d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("5d5992bd-b095-4fdb-8a90-5479d9dfda0f"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a94ee216-8b97-4a27-82d7-00e3418bceda"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("930cf773-5b4a-4c66-89fa-5b1225adc5fa"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("0f6b8c35-69af-444e-8c33-afc4973772c0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"));

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: new Guid("7172c284-148e-49c6-940e-0cecf7f9e512"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52d5f876-7f6d-4441-989a-d509973f829d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("52d5f876-7f6d-4441-989a-d509973f829d"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("7caf3c71-2e75-4de6-8fc3-99ffe2e8d5b5"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("8c0ada49-8685-473c-a7fb-a7ff808d8246"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"));

            migrationBuilder.DeleteData(
                table: "UniversitiesDomains",
                keyColumn: "Id",
                keyValue: new Guid("4a2d363d-0412-47ee-b993-bcf3da104e55"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("1279857c-6eeb-4f2d-87c2-487c75562d53"));

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "Id",
                keyValue: new Guid("a3a9ffa6-c14a-4ce6-bb3e-52136dacb554"));

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "NIP", "Name" },
                values: new object[] { new Guid("ac14e6fa-71a7-4e91-9697-30aa383cc6c0"), "5283121250", "Empty firm in Poland" });

            migrationBuilder.InsertData(
                table: "Entities",
                column: "Id",
                values: new object[]
                {
                    new Guid("0ff3793a-1be0-425f-bdba-0d6fbb47ddab"),
                    new Guid("3d46c8b0-d594-40e3-bb74-3826bebd485f"),
                    new Guid("4daa42e3-ec8d-474e-9df3-e677515b294a"),
                    new Guid("6f3e94e5-ec62-45b9-b3d5-02411c534b8c"),
                    new Guid("ac14e6fa-71a7-4e91-9697-30aa383cc6c0"),
                    new Guid("c8275cb0-4793-48eb-a2bf-7fe174c72a2c"),
                    new Guid("e6204f75-d6a0-4473-8b94-cf950beb1640"),
                    new Guid("f47e73e8-fe8e-49fd-86a6-e8deab775bd0"),
                    new Guid("f8b26051-f58a-4a1c-872c-be7c008ca0c8")
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Building", "City", "Country", "Description", "Education", "EmailAddress", "Experience", "PhoneNumber", "PhotoFile", "Rating", "Region", "ShortDescription", "Street" },
                values: new object[,]
                {
                    { new Guid("0cabe4a6-c279-477f-8d0d-83ea66b66f3d"), "2a", "Gliwice", "Poland", "My university is the best.", "Silesian University of Science, Informatics", "someEmployer@gmail.com", "20 years in Unity", "+2137", null, 0.0m, "Silesia", "My university...", "Akademicka" },
                    { new Guid("4fc77265-561e-4121-ad6d-e3d295e73815"), "2a", "Gliwice", "Poland", "My company is the best.", "Bachelor in Milfology", "someEmployer@gmail.com", "5 years as Milfhunter", "2137", null, 0.0m, "Silesia", "My company...", "Akademicka" }
                });

            migrationBuilder.InsertData(
                table: "UniversitiesDomains",
                columns: new[] { "Id", "EmailDomain" },
                values: new object[] { new Guid("e6204f75-d6a0-4473-8b94-cf950beb1640"), "@polsl.pl" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("0ff3793a-1be0-425f-bdba-0d6fbb47ddab"), "Employer" },
                    { new Guid("4daa42e3-ec8d-474e-9df3-e677515b294a"), "Student" },
                    { new Guid("c8275cb0-4793-48eb-a2bf-7fe174c72a2c"), "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "EmailDomainId", "Name" },
                values: new object[] { new Guid("f47e73e8-fe8e-49fd-86a6-e8deab775bd0"), new Guid("e6204f75-d6a0-4473-8b94-cf950beb1640"), "Politechnika Śląska" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Building", "City", "Country", "EmailAddress", "Name", "PasswordHash", "PhoneNumber", "Region", "RoleId", "SecondName", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("3d46c8b0-d594-40e3-bb74-3826bebd485f"), "2a", "Gliwice", "Poland", "student.debil@polsl.pl", "John", "61646d696e", "+2137", "Silesia", new Guid("4daa42e3-ec8d-474e-9df3-e677515b294a"), "Karol", "Akademicka", "Pavulon" },
                    { new Guid("6f3e94e5-ec62-45b9-b3d5-02411c534b8c"), "2a", "Gliwice", "Poland", "someAdmin@gmail.com", "Admin", "61646d696e31323334", "2137", "Silesia", new Guid("c8275cb0-4793-48eb-a2bf-7fe174c72a2c"), "Adminsky", "Akademicka", "Administator" },
                    { new Guid("f8b26051-f58a-4a1c-872c-be7c008ca0c8"), "2a", "Gliwice", "Poland", "someEmployer@gmail.com", "Adam", "61646d696e", "2137", "Silesia", new Guid("0ff3793a-1be0-425f-bdba-0d6fbb47ddab"), "Szef", "Akademicka", "Małysz" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: new Guid("6f3e94e5-ec62-45b9-b3d5-02411c534b8c"));

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyId", "PositionName" },
                values: new object[] { new Guid("f8b26051-f58a-4a1c-872c-be7c008ca0c8"), new Guid("ac14e6fa-71a7-4e91-9697-30aa383cc6c0"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UniversityId" },
                values: new object[] { new Guid("3d46c8b0-d594-40e3-bb74-3826bebd485f"), new Guid("f47e73e8-fe8e-49fd-86a6-e8deab775bd0") });

            migrationBuilder.InsertData(
                table: "EmployerProfiles",
                columns: new[] { "Id", "CompanyName", "EmployerId", "PositionName" },
                values: new object[] { new Guid("4fc77265-561e-4121-ad6d-e3d295e73815"), "Empty firm in Poland", new Guid("f8b26051-f58a-4a1c-872c-be7c008ca0c8"), "Majster HR" });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "ResumeFile", "StudentId" },
                values: new object[] { new Guid("0cabe4a6-c279-477f-8d0d-83ea66b66f3d"), null, new Guid("3d46c8b0-d594-40e3-bb74-3826bebd485f") });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_StudentProfileId",
                table: "Schedule",
                column: "StudentProfileId");
        }
    }
}
