using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class del : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre_Authors");

            migrationBuilder.DropTable(
                name: "Genre_TypeLiters");

            migrationBuilder.AddColumn<string>(
                name: "Screenings",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Screenings",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "Genre_Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre_Authors", x => new { x.AuthorId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_Genre_Authors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Genre_Authors_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genre_TypeLiters",
                columns: table => new
                {
                    TypeLitId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre_TypeLiters", x => new { x.TypeLitId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_Genre_TypeLiters_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Genre_TypeLiters_Type_Of_Literatures_TypeLitId",
                        column: x => x.TypeLitId,
                        principalTable: "Type_Of_Literatures",
                        principalColumn: "Type_of_literatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Authors_GenreId",
                table: "Genre_Authors",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_TypeLiters_GenreId",
                table: "Genre_TypeLiters",
                column: "GenreId");
        }
    }
}
