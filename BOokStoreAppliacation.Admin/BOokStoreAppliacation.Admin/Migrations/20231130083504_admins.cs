using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAppliacation.Admin.Migrations
{
    public partial class admins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Admin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Admin");
        }
    }
}
