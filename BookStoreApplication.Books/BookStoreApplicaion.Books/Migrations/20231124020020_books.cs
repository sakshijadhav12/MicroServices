using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApplicaion.Books.Migrations
{
    public partial class books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Book_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Ratings = table.Column<float>(nullable: false),
                    Reviews = table.Column<int>(nullable: false),
                    DiscountedPrice = table.Column<float>(nullable: false),
                    OriginalPrice = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Book_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
