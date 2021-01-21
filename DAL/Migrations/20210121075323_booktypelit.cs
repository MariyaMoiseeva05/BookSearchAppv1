using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class booktypelit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Type_Of_Literatures_Type_of_literatureId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Type_of_literatureId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Type_of_literatureId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "TypeOfLit_Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfLit_Books", x => new { x.BookId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_TypeOfLit_Books_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeOfLit_Books_Type_Of_Literatures_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type_Of_Literatures",
                        principalColumn: "Type_of_literatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLit_Books_TypeId",
                table: "TypeOfLit_Books",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOfLit_Books");

            migrationBuilder.AddColumn<int>(
                name: "Type_of_literatureId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Type_of_literatureId",
                table: "Books",
                column: "Type_of_literatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Type_Of_Literatures_Type_of_literatureId",
                table: "Books",
                column: "Type_of_literatureId",
                principalTable: "Type_Of_Literatures",
                principalColumn: "Type_of_literatureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
