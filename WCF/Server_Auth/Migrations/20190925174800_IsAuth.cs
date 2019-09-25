using Microsoft.EntityFrameworkCore.Migrations;

namespace Server_Auth.Migrations
{
    public partial class IsAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuth",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuth",
                table: "Products");
        }
    }
}
