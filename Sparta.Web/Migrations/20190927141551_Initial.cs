using Microsoft.EntityFrameworkCore.Migrations;

namespace Sparta.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}
