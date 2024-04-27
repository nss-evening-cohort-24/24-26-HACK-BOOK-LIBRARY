using _24HackBookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace _24HackBookLibrary.API
{
    public class AuthorAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/authors", (_24HackBookLibraryDbContext db) => //gets all authors without their books
            {
                var authors = db.Authors.ToList();
                if (authors == null)
                {
                    return Results.NotFound("There are no authors");
                }
                return Results.Ok(authors);
            });

            app.MapGet("/authors/books",(_24HackBookLibraryDbContext db) =>  //gets all authors with their books
            {
                var authors = db.Authors.Include(b => b.Books).ToList();
                if (authors == null)
                {
                    return Results.NotFound("There are no authors");
                }
                return Results.Ok(authors);

            });

            app.MapGet("/authors/{id}", (_24HackBookLibraryDbContext db, int id) => //gets a single author without their books
            {
                var author = db.Authors.FirstOrDefault(a => a.Id == id);

                if (author == null)
                {
                    return Results.NotFound("No Author Found");
                }

                return Results.Ok(author);
            });

            app.MapGet("/authors/{id}/books", (_24HackBookLibraryDbContext db, int id) => //gets a single author with their books
            {
                var author = db.Authors.Include(b => b.Books).FirstOrDefault(b => b.Id == id);

                if (author == null)
                {
                    return Results.NotFound("No Author Found");
                }

                return Results.Ok(author);
            });

            app.MapPost("/authors", (_24HackBookLibraryDbContext db, NewAuthorDTO newAuthor) => //posts an author by just their name
            {
                try
                {
                    Author authorToCreate = new()
                    {
                        Name = newAuthor.Name,
                    };

                    db.Authors.Add(authorToCreate);
                    db.SaveChanges();
                    return Results.Created($"/authors/{authorToCreate.Id}", newAuthor);

                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to add author");
                }
            });

            app.MapPut("/authors/{id}", (_24HackBookLibraryDbContext db, int id, NewAuthorDTO newAuthor) =>
            {
                var authorToUpdate = db.Authors.FirstOrDefault(a => a.Id == id);
                if (authorToUpdate == null)
                {
                    return Results.NotFound("Author not found");
                }

                authorToUpdate.Name = newAuthor.Name;

                db.SaveChanges();

                return Results.Created(authorToUpdate.Name, newAuthor);
            });
        }
    }
}
