using _24HackBookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace _24HackBookLibrary.API
{
    public class BookUserAPI
    {
        public static void Map(WebApplication app)
        {
            //Add Book to User bookshelf
            app.MapPost("/books/addToShelf", (_24HackBookLibraryDbContext db, AddBookDTO bookUser) =>
            {
                User userBookshelfBeingAddedTo = db.Users.Include(u => u.Books).SingleOrDefault(u => u.Id == bookUser.UserId);
                if (userBookshelfBeingAddedTo == null)
                {
                    return Results.NotFound("User not found");
                }

                Book bookBeingAdded = db.Books.FirstOrDefault(b => b.Id == bookUser.BookId);
                if (bookBeingAdded == null)
                {
                    return Results.NotFound("Book not found");
                }

                userBookshelfBeingAddedTo.Books.Add(bookBeingAdded);
                db.SaveChanges();
                return Results.Created($"/book/addToShelf", bookUser);
            });

            //Remove Book from User bookshelf
            app.MapDelete("/books/{bookId}/{userId}", (_24HackBookLibraryDbContext db, int bookId, int userId) =>
            {
                var userBookshelfBeingRemovedFrom = db.Users.Include(u => u.Books).SingleOrDefault(u => u.Id == userId);
                if (userBookshelfBeingRemovedFrom == null)
                {
                    return Results.NotFound("User not found");
                }

                var bookBeingRemoved = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (bookBeingRemoved == null)
                {
                    return Results.NotFound("Book not found");
                }

                userBookshelfBeingRemovedFrom.Books.Remove(bookBeingRemoved);
                db.SaveChanges();
                return Results.NoContent();
            });

            //Get user's bookshelf books
            app.MapGet("/bookuser/{userId}", async (_24HackBookLibraryDbContext db, int userId) =>
            {
                var user = await db.Users
                    .Include(u => u.Books).ThenInclude(b => b.Comments)
                    .Include(u => u.Books).ThenInclude(b => b.Author)
                    .Include(u => u.Books).ThenInclude(b => b.Genre)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return Results.NotFound("User not found");
                }

                var bookShelf = user.Books?.Select(book => new
                {
                    book.Id,
                    book.Title,
                    book.BookCover,
                    AuthorName = book.Author.Name,
                    GenreName = book.Genre.GenreName,
                    book.PublishYear,
                    Comments = book.Comments?.Select(comment => new
                    {
                        comment.Id,
                        comment.Content
                    }).ToList()
                }).ToList();

                if (bookShelf == null || !bookShelf.Any())
                {
                    return Results.NotFound("");
                }

                return Results.Ok(bookShelf);
            });
        }
    }
}
