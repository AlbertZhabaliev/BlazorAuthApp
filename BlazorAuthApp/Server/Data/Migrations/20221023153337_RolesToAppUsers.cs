using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAuthApp.Server.Data.Migrations
{
    public partial class RolesToAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "AppUsers");
        }
    }
}
