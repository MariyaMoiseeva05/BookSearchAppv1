using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Advertnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    LocalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Timezone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.LocalityId);
                });

            migrationBuilder.CreateTable(
                name: "Advert",
                columns: table => new
                {
                    AdvertID = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    LocalityId = table.Column<int>(nullable: false),
                    ExchangeCompleted = table.Column<bool>(nullable: false),
                    SaleCompleted = table.Column<bool>(nullable: false),
                    Finish = table.Column<bool>(nullable: false),
                    Date_of_Create = table.Column<DateTime>(nullable: false),
                    Number_of_views = table.Column<int>(nullable: false),
                    Delivery = table.Column<bool>(nullable: false),
                    Pickup = table.Column<bool>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advert", x => x.AdvertID);
                    table.ForeignKey(
                        name: "FK_Advert_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advert_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "LocalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advert_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment_Adverts",
                columns: table => new
                {
                    Comment_AdvertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Date_of_AddComment = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    AdvertId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment_Adverts", x => x.Comment_AdvertId);
                    table.ForeignKey(
                        name: "FK_Comment_Adverts_Advert_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Advert",
                        principalColumn: "AdvertID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Adverts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Featured_Adverts",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    AdvertId = table.Column<string>(nullable: false),
                    Featured_AdvertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Featured_Adverts", x => new { x.AdvertId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Featured_Adverts_Advert_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Advert",
                        principalColumn: "AdvertID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Featured_Adverts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like_Adverts",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    AdvertId = table.Column<string>(nullable: false),
                    Like_AdvertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like_Adverts", x => new { x.AdvertId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Like_Adverts_Advert_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Advert",
                        principalColumn: "AdvertID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Adverts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Sender_Id = table.Column<string>(nullable: false),
                    Recipient_Id = table.Column<string>(nullable: false),
                    Readed = table.Column<bool>(nullable: false),
                    Create_Message = table.Column<DateTime>(nullable: false),
                    AdvertId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Advert_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Advert",
                        principalColumn: "AdvertID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_Sender_Id",
                        column: x => x.Sender_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advert_BookId",
                table: "Advert",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Advert_LocalityId",
                table: "Advert",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Advert_UserId",
                table: "Advert",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Adverts_AdvertId",
                table: "Comment_Adverts",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Adverts_UserId",
                table: "Comment_Adverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Featured_Adverts_UserId",
                table: "Featured_Adverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_Adverts_UserId",
                table: "Like_Adverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AdvertId",
                table: "Messages",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Sender_Id",
                table: "Messages",
                column: "Sender_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment_Adverts");

            migrationBuilder.DropTable(
                name: "Featured_Adverts");

            migrationBuilder.DropTable(
                name: "Like_Adverts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Advert");

            migrationBuilder.DropTable(
                name: "Localities");
        }
    }
}
