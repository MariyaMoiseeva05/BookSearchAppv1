using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class featuredBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Books_BookId",
                table: "Advert");

            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Localities_LocalityId",
                table: "Advert");

            migrationBuilder.DropForeignKey(
                name: "FK_Advert_AspNetUsers_UserId",
                table: "Advert");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Adverts_Advert_AdvertId",
                table: "Comment_Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Featured_Adverts_Advert_AdvertId",
                table: "Featured_Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Adverts_Advert_AdvertId",
                table: "Like_Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Advert_AdvertId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advert",
                table: "Advert");

            migrationBuilder.RenameTable(
                name: "Advert",
                newName: "Adverts");

            migrationBuilder.RenameIndex(
                name: "IX_Advert_UserId",
                table: "Adverts",
                newName: "IX_Adverts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advert_LocalityId",
                table: "Adverts",
                newName: "IX_Adverts_LocalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Advert_BookId",
                table: "Adverts",
                newName: "IX_Adverts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts",
                column: "AdvertID");

            migrationBuilder.CreateTable(
                name: "Featured_Books",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Featured_BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Featured_Books", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Featured_Books_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Featured_Books_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Featured_Books_UserId",
                table: "Featured_Books",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Books_BookId",
                table: "Adverts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Localities_LocalityId",
                table: "Adverts",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "LocalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AspNetUsers_UserId",
                table: "Adverts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Adverts_Adverts_AdvertId",
                table: "Comment_Adverts",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Featured_Adverts_Adverts_AdvertId",
                table: "Featured_Adverts",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Adverts_Adverts_AdvertId",
                table: "Like_Adverts",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Adverts_AdvertId",
                table: "Messages",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Books_BookId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Localities_LocalityId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AspNetUsers_UserId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Adverts_Adverts_AdvertId",
                table: "Comment_Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Featured_Adverts_Adverts_AdvertId",
                table: "Featured_Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Adverts_Adverts_AdvertId",
                table: "Like_Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Adverts_AdvertId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Featured_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts");

            migrationBuilder.RenameTable(
                name: "Adverts",
                newName: "Advert");

            migrationBuilder.RenameIndex(
                name: "IX_Adverts_UserId",
                table: "Advert",
                newName: "IX_Advert_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Adverts_LocalityId",
                table: "Advert",
                newName: "IX_Advert_LocalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Adverts_BookId",
                table: "Advert",
                newName: "IX_Advert_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advert",
                table: "Advert",
                column: "AdvertID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Books_BookId",
                table: "Advert",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Localities_LocalityId",
                table: "Advert",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "LocalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_AspNetUsers_UserId",
                table: "Advert",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Adverts_Advert_AdvertId",
                table: "Comment_Adverts",
                column: "AdvertId",
                principalTable: "Advert",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Featured_Adverts_Advert_AdvertId",
                table: "Featured_Adverts",
                column: "AdvertId",
                principalTable: "Advert",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Adverts_Advert_AdvertId",
                table: "Like_Adverts",
                column: "AdvertId",
                principalTable: "Advert",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Advert_AdvertId",
                table: "Messages",
                column: "AdvertId",
                principalTable: "Advert",
                principalColumn: "AdvertID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
