using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class author_book_foreign_key_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Books_Authors_BookId",
                table: "Author_Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_of_Death",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_of_Birth",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Author_Books_AuthorId",
                table: "Author_Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Books_Authors_AuthorId",
                table: "Author_Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Books_Authors_AuthorId",
                table: "Author_Books");

            migrationBuilder.DropIndex(
                name: "IX_Author_Books_AuthorId",
                table: "Author_Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_of_Death",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_of_Birth",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Books_Authors_BookId",
                table: "Author_Books",
                column: "BookId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
