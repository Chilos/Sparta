using Microsoft.EntityFrameworkCore.Migrations;

namespace Sparta.Web.Migrations
{
    public partial class addRealName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealName",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealName",
                table: "User");
        }
    }
}
