using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddCRCN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "NewsId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReviewRewiewId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "Comments_News",
                columns: table => new
                {
                    Comment_NewsId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    NewsId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date_of_creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments_News", x => x.Comment_NewsId);
                    table.ForeignKey(
                        name: "FK_Comments_News_News_Comment_NewsId",
                        column: x => x.Comment_NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_News_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments_Review",
                columns: table => new
                {
                    Comment_ReviewId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date_of_creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments_Review", x => x.Comment_ReviewId);
                    table.ForeignKey(
                        name: "FK_Comments_Review_Reviews_Comment_ReviewId",
                        column: x => x.Comment_ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "RewiewId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_News_UserId",
                table: "Comments_News",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Review_UserId",
                table: "Comments_Review",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments_News");

            migrationBuilder.DropTable(
                name: "Comments_Review");

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewRewiewId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(max)",
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
    }
}
