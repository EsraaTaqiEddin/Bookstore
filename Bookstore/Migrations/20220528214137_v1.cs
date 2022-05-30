using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Migrations
{
    public partial class v1 : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Categories_CategoriesID",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_CategoriesID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CategoriesID",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesID",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CategoriesID",
                table: "Authors",
                column: "CategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Categories_CategoriesID",
                table: "Authors",
                column: "CategoriesID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
