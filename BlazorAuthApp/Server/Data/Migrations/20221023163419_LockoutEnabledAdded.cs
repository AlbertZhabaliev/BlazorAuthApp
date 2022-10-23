using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAuthApp.Server.Data.Migrations
{
    public partial class LockoutEnabledAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AppUsers");
        }
    }
}
