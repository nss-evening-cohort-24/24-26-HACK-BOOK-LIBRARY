using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _24HackBookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserBookRatingsTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.CreateTable(
                name: "UserBookRatings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookRatings", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_UserBookRatings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookRatings_BookId",
                table: "UserBookRatings",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "UserBookRatings");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenreId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "Content", "DatePosted", "UserId" },
                values: new object[,]
                {
                    { 6, 6, "What a mezmerizingly weird little book.", new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 7, 7, "I just accidentally reread this book in one sitting...", new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 7 }
                });
        }
    }
}
