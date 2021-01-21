using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class com : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Type",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewRewiewId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewRewiewId",
                table: "Comments",
                column: "ReviewRewiewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_ReviewRewiewId",
                table: "Comments",
                column: "ReviewRewiewId",
                principalTable: "Reviews",
                principalColumn: "RewiewId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_ReviewRewiewId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_NewsId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReviewRewiewId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReviewRewiewId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
