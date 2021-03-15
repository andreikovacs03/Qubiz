using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core.Migrations
{
    public partial class added_book_properteies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Books");
        }
    }
}
