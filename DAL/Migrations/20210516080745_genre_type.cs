using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class genre_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types_Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types_Genres", x => new { x.GenreId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_Types_Genres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Types_Genres_Type_Of_Literatures_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type_Of_Literatures",
                        principalColumn: "Type_of_literatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Types_Genres_TypeId",
                table: "Types_Genres",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Types_Genres");
        }
    }
}
