using _24HackBookLibrary.Models;

namespace _24HackBookLibrary.API
{
    public static class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/comments", (_24HackBookLibraryDbContext db, AddCommentDTO dto) => // Posts a new comment
            {
                if (dto.UserId <= 0 || dto.BookId <= 0 || string.IsNullOrWhiteSpace(dto.Content))
                {
                    return Results.BadRequest("Invalid data provided.");
                }

                if (!db.Users.Any(u => u.Id == dto.UserId) || !db.Books.Any(b => b.Id == dto.BookId))
                {
                    return Results.NotFound("User or book not found.");
                }

                var newComment = new Comment
                {
                    UserId = dto.UserId,
                    BookId = dto.BookId,
                    Content = dto.Content,
                    DatePosted = DateTime.UtcNow
                };

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

