using _24HackBookLibrary.Models;

namespace _24HackBookLibrary.API
{
    public static class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/comments", (_24HackBookLibraryDbContext db, Comment newComment) => //Posts a new comment
            {
                if (newComment.UserId <= 0 || newComment.BookId <= 0 || string.IsNullOrWhiteSpace(newComment.Content))
                {
                    return Results.BadRequest("Invalid data provided.");
                }

                var userExists = db.Users.Any(u => u.Id == newComment.UserId);
                var bookExists = db.Books.Any(b => b.Id == newComment.BookId);

                if (!userExists || !bookExists)
                {
                    return Results.NotFound("User or book not found.");
                }

                newComment.DatePosted = DateTime.UtcNow;
                db.Comments.Add(newComment);
                db.SaveChanges();

                return Results.Created($"/comments/{newComment.Id}", newComment);
            });

            app.MapGet("/comments", (_24HackBookLibraryDbContext db) => // Gets all comments
            {
                var comments = db.Comments.ToList();
                if (comments == null || !comments.Any())
                {
                    return Results.NotFound("No comments found.");
                }
                return Results.Ok(comments);
            });

            app.MapGet("/comments/{id}", (_24HackBookLibraryDbContext db, int id) => // Gets a specific comment by ID
            {
                var comment = db.Comments.FirstOrDefault(c => c.Id == id);
                if (comment == null)
                {
                    return Results.NotFound($"No comment found with ID {id}.");
                }
                return Results.Ok(comment);
            });

            app.MapPut("/comments/{id}", (_24HackBookLibraryDbContext db, int id, Comment updatedComment) => //Updates Comment by ID
            {
                var commentToUpdate = db.Comments.FirstOrDefault(c => c.Id == id);

                commentToUpdate.Content = updatedComment.Content;

                db.SaveChanges();

                return Results.Ok(commentToUpdate);
            });

            app.MapDelete("/comments/{id}", (_24HackBookLibraryDbContext db, int id) => //Deletes Comment by ID
            {
                var commentToDelete = db.Comments.FirstOrDefault(c => c.Id == id);
                if (commentToDelete == null)
                {
                    return Results.NotFound();
                }

                db.Comments.Remove(commentToDelete);
                db.SaveChanges();

                return Results.NoContent();
            });



        }
    }
}

