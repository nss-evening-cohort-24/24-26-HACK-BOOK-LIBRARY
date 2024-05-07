using _24HackBookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace _24HackBookLibrary.API
{
    public class RatingAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/ratings/book/{bookId}", (_24HackBookLibraryDbContext db, int bookId) => //gets avg rating for single book
            {
                var bookRatings = db.UserBookRatings.Where(ubr => ubr.BookId == bookId).Select(ubr => ubr.Score).ToList();
                if(bookRatings == null || bookRatings.Count == 0)
                {

                return Results.NotFound("This book hasnt been rated yet");
                }
                else
                {

                    var averageScore = bookRatings.Average();
                 
                    return Results.Ok(averageScore);
                    
                }
            });

            app.MapGet("/ratings/book/{bookId}/user/{userId}", (_24HackBookLibraryDbContext db, int bookId, int userId) => // gets single users rating for single book
            {
                var usersBookRating = db.UserBookRatings.Where(ubr => ubr.UserId == userId && ubr.BookId == bookId).Select(ubr => ubr.Score).FirstOrDefault();
                if (usersBookRating != null)
                {
                    return Results.Ok(usersBookRating);
                }
                return Results.NotFound("You havent rated this book yet");
            });

            app.MapGet("/ratings/book/user/{userId}", (_24HackBookLibraryDbContext db, int userId) => // get all of single users ratings
            {
                var usersRatings = db.UserBookRatings.Where(ubr => ubr.UserId == userId).ToList();
                if (usersRatings != null)
                {
                    return Results.Ok(usersRatings);
                }
                return Results.NotFound("This user hasnt rated anything yet");
            });

            app.MapPost("/ratings/user", (_24HackBookLibraryDbContext db, RatingDTO userBookRating) => // create new rating
            {
                try
                {
                UserBookRating newRating = new()
                {
                    Id = userBookRating.Id,
                    UserId = userBookRating.UserId,
                    BookId = userBookRating.BookId,
                    Score = userBookRating.Score,
                };
                db.UserBookRatings.Add(newRating);
                db.SaveChanges();
                return Results.Created($"/ratings/{newRating.Id}", newRating);
                }
                catch (DbUpdateException) 
                {
                    return Results.BadRequest("Unable to rate this book");
                }
            });

            app.MapPut("/ratings/book/{bookId}/user/{userId}", (_24HackBookLibraryDbContext db, int userId, int bookId, RatingDTO updatedRating) =>
            {
                var userBookRatingToUpdate = db.UserBookRatings.FirstOrDefault(ubr => ubr.UserId == userId && ubr.BookId == bookId);
                if (userBookRatingToUpdate == null)
                {
                    return Results.NotFound("This user hasnt rated this book yet");
                }
                else
                {
                    userBookRatingToUpdate.Score = updatedRating.Score ;
                    db.SaveChanges();
                    return Results.Created($"/ratings/{updatedRating.Id}", userBookRatingToUpdate);
                }
            });

        }

    }
}
