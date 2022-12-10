using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4SRegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedRolesforIdentification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "Employers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "Administrators",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoleId",
                table: "Students",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_RoleId",
                table: "Employers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_RoleId",
                table: "Administrators",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_Roles_RoleId",
                table: "Administrators",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Roles_RoleId",
                table: "Employers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Roles_RoleId",
                table: "Students",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrators_Roles_RoleId",
                table: "Administrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Roles_RoleId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Roles_RoleId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoleId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Employers_RoleId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_RoleId",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Administrators");
        }
    }
}
