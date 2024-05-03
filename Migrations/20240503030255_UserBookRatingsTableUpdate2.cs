using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _24HackBookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserBookRatingsTableUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserBookRatings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "UserBookRatings",
                columns: new[] { "BookId", "UserId", "Id", "Score" },
                values: new object[,]
                {
                    { 3, 1, 4, 3 },
                    { 1, 2, 5, 4 },
                    { 2, 4, 1, 5 },
                    { 4, 18, 3, 5 },
                    { 6, 18, 2, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserBookRatings");
        }
    }
}
