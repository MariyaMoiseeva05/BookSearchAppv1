using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Genre_TypeLit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre_TypeLiters",
                columns: table => new
                {
                    TypeLitId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
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
                name: "IX_Genre_TypeLiters_GenreId",
                table: "Genre_TypeLiters",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre_TypeLiters");
        }
    }
}
