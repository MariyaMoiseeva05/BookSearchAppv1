using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Collection_character : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorsAuthorId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Author_Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author_Books", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_Author_Books_Authors_BookId",
                        column: x => x.BookId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Author_Books_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Other_name = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    View = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    Appearance = table.Column<string>(nullable: true),
                    Date_of_Birth = table.Column<DateTime>(nullable: false),
                    Date_of_Death = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                });

            migrationBuilder.CreateTable(
                name: "Book_Characters",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Characters", x => new { x.BookId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_Book_Characters_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Characters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Collections",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    CollectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Collections", x => new { x.BookId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_Book_Collections_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Collections_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorsAuthorId",
                table: "Books",
                column: "AuthorsAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Characters_CharacterId",
                table: "Book_Characters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Collections_CollectionId",
                table: "Book_Collections",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorsAuthorId",
                table: "Books",
                column: "AuthorsAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorsAuthorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Author_Books");

            migrationBuilder.DropTable(
                name: "Book_Characters");

            migrationBuilder.DropTable(
                name: "Book_Collections");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorsAuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorsAuthorId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
