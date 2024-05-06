using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _24HackBookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserBookRatingsKeyFixbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBookRatings",
                table: "UserBookRatings");

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

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "UserBookRatings",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserBookRatings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBookRatings",
                table: "UserBookRatings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "UserBookRatings",
                columns: new[] { "Id", "BookId", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 5.0, 4 },
                    { 2, 6, 5.0, 18 },
                    { 3, 4, 5.0, 18 },
                    { 4, 3, 3.0, 1 },
                    { 5, 1, 4.0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBookRatings_UserId",
                table: "UserBookRatings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBookRatings",
                table: "UserBookRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserBookRatings_UserId",
                table: "UserBookRatings");

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserBookRatings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "UserBookRatings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserBookRatings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBookRatings",
                table: "UserBookRatings",
                columns: new[] { "UserId", "BookId" });

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
    }
}
