using Microsoft.EntityFrameworkCore.Migrations;

namespace Sparta.Web.Migrations
{
    public partial class changePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedChangePassword",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedChangePassword",
                table: "User");
        }
    }
}
