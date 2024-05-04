namespace _24HackBookLibrary.API
{
    public class RatingAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/ratings/book/{bookId}", (_24HackBookLibraryDbContext db, int bookId) => //gets avg rating
            {
                var bookRatings = db.UserBookRatings.Where(ubr => ubr.Id == bookId).Select(ubr => ubr.Score).ToList();
                if (bookRatings != null)
                {

                    var averageScore = bookRatings.Average();
                    return Results.Ok(averageScore);
                    
                }
                return Results.NotFound("This book hasnt been rated yet");
            });

        }

    }
}
