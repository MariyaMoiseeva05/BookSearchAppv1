using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DataRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Interesting_Facts_Authors_AuthorID",
                table: "Interesting_Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookID",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Quotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewRewiewId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookID",
                table: "Comments",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interesting_Facts_Authors_AuthorID",
                table: "Interesting_Facts",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookID",
                table: "Reviews",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Interesting_Facts_Authors_AuthorID",
                table: "Interesting_Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Quotes");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewRewiewId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookID",
                table: "Comments",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interesting_Facts_Authors_AuthorID",
                table: "Interesting_Facts",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookID",
                table: "Reviews",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
