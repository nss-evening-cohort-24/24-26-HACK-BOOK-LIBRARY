using Microsoft.EntityFrameworkCore;

namespace _24HackBookLibrary.API
{
    public class SearchAPI
    {
        public static void Map(WebApplication app)
        {
            //Get books by title, genre, and author name
            app.MapGet("/search/books", (_24HackBookLibraryDbContext db, string query) =>
            {
                if (string.IsNullOrEmpty(query))
                {
                    return Results.BadRequest("Search query cannot be empty.");
                }

                var normalizedQuery = query.Trim().ToLower();

                var books = db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Where(b => b.Title.ToLower().Contains(normalizedQuery) ||
                                b.Author.Name.ToLower().Contains(normalizedQuery) ||
                                b.Genre.GenreName.ToLower().Contains(normalizedQuery))
                    .Select(b => new
                    {
                        BookId = b.Id,
                        Title = b.Title,
                        AuthorName = b.Author.Name,
                        GenreName = b.Genre.GenreName,
                        BookCover = b.BookCover
                    })
                    .ToList();

                if (books == null || books.Count == 0)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(books);
            });

            //Search author and their books by author name
            app.MapGet("/search/authors", (_24HackBookLibraryDbContext db, string query) =>
            {
                if (string.IsNullOrEmpty(query))
                {
                    return Results.BadRequest("Search query cannot be empty.");
                }

                var normalizedQuery = query.Trim().ToLower();

                var authors = db.Authors.Include(a => a.Books).Where(a => a.Name.ToLower().Contains(normalizedQuery))
                            .Select(a => new
                            {
                                Id = a.Id,
                                Name = a.Name,
                                Books = a.Books
                            })
                        .ToList();

                if (authors == null || authors.Count == 0)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(authors);
            });
        }
    }
}
