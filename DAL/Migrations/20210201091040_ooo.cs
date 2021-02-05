using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorsAuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorsAuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorsAuthorId",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorsAuthorId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorsAuthorId",
                table: "Books",
                column: "AuthorsAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorsAuthorId",
                table: "Books",
                column: "AuthorsAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
