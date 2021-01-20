using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_name = table.Column<string>(nullable: false),
                    Pseudonym = table.Column<string>(nullable: true),
                    Date_of_Birth = table.Column<DateTime>(nullable: false),
                    Date_of_Death = table.Column<DateTime>(nullable: false),
                    Place_of_Birth = table.Column<string>(nullable: true),
                    Place_of_Death = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    Years_of_creativity = table.Column<string>(nullable: true),
                    Language_of_works = table.Column<string>(nullable: true),
                    Debut = table.Column<string>(nullable: true),
                    Prizes = table.Column<string>(nullable: true),
                    Awards = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGenre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ImageLink = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Date_of_creation = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thinks",
                columns: table => new
                {
                    ThinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Date_of_creation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thinks", x => x.ThinkId);
                });

            migrationBuilder.CreateTable(
                name: "Type_Of_Literatures",
                columns: table => new
                {
                    Type_of_literatureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Literatures", x => x.Type_of_literatureId);
                });

            migrationBuilder.CreateTable(
                name: "Interesting_Facts",
                columns: table => new
                {
                    FactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorID = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    ImageLink = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interesting_Facts", x => x.FactId);
                    table.ForeignKey(
                        name: "FK_Interesting_Facts_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News_Tags",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News_Tags", x => new { x.NewsId, x.TagId });
                    table.ForeignKey(
                        name: "FK_News_Tags_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_News_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Edition = table.Column<string>(nullable: true),
                    Publication_date = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true),
                    Type_of_literatureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Type_Of_Literatures_Type_of_literatureId",
                        column: x => x.Type_of_literatureId,
                        principalTable: "Type_Of_Literatures",
                        principalColumn: "Type_of_literatureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Date_of_creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genre_Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre_Books", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_Genre_Books_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Genre_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quotes_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    RewiewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Text = table.Column<string>(maxLength: 5000, nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    BookID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.RewiewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Type_of_literatureId",
                table: "Books",
                column: "Type_of_literatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookID",
                table: "Comments",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Books_GenreId",
                table: "Genre_Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Interesting_Facts_AuthorID",
                table: "Interesting_Facts",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_News_Tags_TagId",
                table: "News_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_BookID",
                table: "Quotes",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookID",
                table: "Reviews",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Genre_Books");

            migrationBuilder.DropTable(
                name: "Interesting_Facts");

            migrationBuilder.DropTable(
                name: "News_Tags");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Thinks");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Type_Of_Literatures");
        }
    }
}
