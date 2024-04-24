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
                return db.Authors.ToList();
            });

            app.MapGet("/authors/books",(_24HackBookLibraryDbContext db) =>  //gets all authors with their books
            {
                return db.Authors.Include(b => b.Books).ToList();   
            });

            app.MapGet("/authors/{id}", (_24HackBookLibraryDbContext db, int id) => //gets a single author without their books
            {
                return db.Authors.FirstOrDefault(a => a.Id == id);
            });

            app.MapGet("/authors/{id}/books", (_24HackBookLibraryDbContext db, int id) => //gets a single author with their books
            {
                return db.Authors.Include(b => b.Books).FirstOrDefault(b => b.Id == id);
            });

            app.MapPost("/authors", (_24HackBookLibraryDbContext db, NewAuthorDTO newAuthor) => //posts an author by just their name
            {
                Author authorToCreate = new()
                {
                    Name = newAuthor.Name,
                };

                db.Authors.Add(authorToCreate);

                db.SaveChanges();

                return Results.Created($"/authors/{authorToCreate.Id}", newAuthor);
            });

            app.MapPut("/authors/{id}", (_24HackBookLibraryDbContext db, int id, NewAuthorDTO newAuthor) =>
            {
                var authorToUpdate = db.Authors.FirstOrDefault(a => a.Id == id);

                authorToUpdate.Name = newAuthor.Name;

                db.SaveChanges();

                return Results.Created(authorToUpdate.Name, newAuthor);
            });
        }
    }
}
