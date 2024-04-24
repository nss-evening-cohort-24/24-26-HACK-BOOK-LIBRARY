using _24HackBookLibrary.Models;
using Microsoft.EntityFrameworkCore;

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

                Book bookBeingAdded = db.Books.SingleOrDefault(b => b.Id == bookUser.BookId);
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

                var bookBeingRemoved = db.Books.SingleOrDefault(b => b.Id == bookId);
                if (bookBeingRemoved == null)
                {
                    return Results.NotFound("Book not found");
                }

                userBookshelfBeingRemovedFrom.Books.Remove(bookBeingRemoved);
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
