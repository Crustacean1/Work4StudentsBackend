using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W4SRegistrationMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class companyemployerchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NIP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIP",
                table: "Companies");
        }
    }
}
