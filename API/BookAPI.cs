using _24HackBookLibrary.Models;
using Microsoft.EntityFrameworkCore;
namespace _24HackBookLibrary.API
{
    public class BookAPI
    {
        public static void Map(WebApplication app)
        {
            //Get all books with comments
            app.MapGet("/books/comments", (_24HackBookLibraryDbContext db) =>
            {
                var books = db.Books.Include(b => b.Comments).ToList();

                if (books == null)
                {
                    return Results.NotFound("No books found");
                }
                return Results.Ok(books);
            });

            //Get all books 
            app.MapGet("/books", async (_24HackBookLibraryDbContext db, string sortBy = "title") =>
            {
                var books = await db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.UserBookRatings)
                    .Select(book => new
                    {
                        BookId = book.Id,
                        PublishYear = book.PublishYear,
                        Title = book.Title,
                        AuthorName = book.Author.Name,
                        BookCover = book.BookCover,
                        GenreName = book.Genre.GenreName,
                        AverageRating = db.UserBookRatings
                                .Where(rating => rating.BookId == book.Id)
                                .Average(rating => (double?)rating.Score)
                    })
            .OrderBy(book => book.Title)
            .ToListAsync();

                if (books == null || !books.Any())
                {
                    return Results.NotFound("No books found.");
                }

                return Results.Ok(books);
            });




            //Get single book
            app.MapGet("/books/{id}", (_24HackBookLibraryDbContext db, int id) =>
            {
                var book = db.Books.FirstOrDefault(b => b.Id == id);

                if (book == null)
                {
                    return Results.NotFound("Book not found");
                }
                return Results.Ok(book);
            });
            //get specific book details
            app.MapGet("/books/{id}/author/genre/rating", (_24HackBookLibraryDbContext db, int id) =>
            {
                var book = db.Books
                    .Where(b => b.Id == id)
                    .Select(b => new
                    {
                        b.Id,
                        b.Title,
                        b.PublishYear,
                        b.Author.Name, 
                        b.Genre.GenreName,
                        b.BookCover,
                        
                    })
                    .FirstOrDefault();

                if (book == null)
                {
                    return Results.NotFound("Book not found");
                }
                return Results.Ok(book);
            });

            //Get single book with comments and their users (this is not needed any more see: commentAPI for get commentsForBook)
            app.MapGet("/books/{id}/comments", (_24HackBookLibraryDbContext db, int id) =>
            {
                var book = db.Books.Include(u => u.User).FirstOrDefault(b => b.Id == id);

                if (book == null)
                {
                    return Results.NotFound("Book not found");
                }
                return Results.Ok(book);
            });


            //Delete a book
            app.MapDelete("/books/{id}", (_24HackBookLibraryDbContext db, int id) =>
            {
                var bookToDelete = db.Books.FirstOrDefault(b => b.Id == id);

                if (bookToDelete == null)
                {
                    return Results.NotFound("Book not found");
                }
                db.Books.Remove(bookToDelete);
                db.SaveChanges();
                return Results.Ok("Book deleted.");
            });

            //Create a book
            app.MapPost("/books", (_24HackBookLibraryDbContext db, Book newBook) =>
            {
                try
                {
                    db.Books.Add(newBook);
                    db.SaveChanges();
                    return Results.Created($"/users/{newBook.Id}", newBook);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to add book");
                }
            });

            //Edit a book
            app.MapPut("/books/{id}", (_24HackBookLibraryDbContext db, int id, Book updatedBook) =>
            {
                var originalBookDetails = db.Books.FirstOrDefault(b => b.Id == id);

                if (originalBookDetails == null)
                {
                    return Results.NotFound("Book not found");
                }

                originalBookDetails.Title = updatedBook.Title;
                originalBookDetails.BookCover = updatedBook.BookCover;
                originalBookDetails.AuthorId = updatedBook.AuthorId;
                originalBookDetails.GenreId = updatedBook.GenreId;
                originalBookDetails.PublishYear = updatedBook.PublishYear;
                db.SaveChanges();
                return Results.Ok("Book details updated successfully");
            });

           
        }
    }
}
