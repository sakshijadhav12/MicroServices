using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAppliacation.Admin.Migrations
{
    public partial class table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "AdminEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminEntity",
                table: "AdminEntity",
                column: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminEntity",
                table: "AdminEntity");

            migrationBuilder.RenameTable(
                name: "AdminEntity",
                newName: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "AdminId");
        }
    }
}
