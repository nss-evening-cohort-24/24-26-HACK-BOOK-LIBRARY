using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _24HackBookLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    BookCover = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    PublishYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BookId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Anne Frank" },
                    { 2, 2, "Madeline L'Engle" },
                    { 3, 3, "Jack Weatherford" },
                    { 4, 4, "Steven Erikson" },
                    { 5, 5, "Dan Brown" },
                    { 6, 6, "Douglas Adams" },
                    { 7, 7, "Suzanne Collins" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "Biography" },
                    { 2, "Children's" },
                    { 3, "History" },
                    { 4, "Fantasy" },
                    { 5, "Mystery" },
                    { 6, "Science-Fiction" },
                    { 7, "Young Adult" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Email", "Uid", "UserName" },
                values: new object[,]
                {
                    { 1, "Test", "GregMarkus1992@gmail.com", "", "GMarkus" },
                    { 2, "Test", "nathopp@gmail.com", "", "NWelton" },
                    { 3, "Test", "HSmith@email.com", "", "HSmith" },
                    { 4, "Test", "mrthincrisp@gmail.com", "", "DSwann" },
                    { 5, "Test", "B33blebroxx@gmail.com", "", "BSchnurb" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookCover", "GenreId", "PublishYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1560816565l/48855.jpg", 1, 1947, "The Diary of a Young Girl" },
                    { 2, 2, "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1507963312l/33574273._SX318_.jpg", 2, 1962, "A Wrinkle in Time" },
                    { 3, 3, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1530716694i/40718726.jpg", 3, 2004, "Genghis Khan and the Making of the Modern World" },
                    { 4, 4, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1548497031i/55399.jpg", 4, 1999, "Gardens of the Moon" },
                    { 5, 5, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1696691404i/960.jpg", 5, 2000, "Angels and Demons" },
                    { 6, 6, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1531891848i/11.jpg", 6, 1979, "The Hitchhiker's Guide to the Galaxy" },
                    { 7, 7, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1586722975i/2767052.jpg", 7, 2008, "The Hunger Games" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "Content", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "A very important historical work.", 1 },
                    { 2, 2, "Wild and imaginative!", 2 },
                    { 3, 3, "A bit biased but otherwise worth reading.", 3 },
                    { 4, 4, "I get the feeling the entire Malazan series will benefit from a reread.", 4 },
                    { 5, 5, "The battle between Science and religion is a fascinating topic to read.", 5 },
                    { 6, 6, "What a mezmerizingly weird little book.", 6 },
                    { 7, 7, "I just accidentally reread this book in one sitting...", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
