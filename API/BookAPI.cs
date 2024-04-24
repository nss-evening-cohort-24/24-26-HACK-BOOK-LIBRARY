﻿using _24HackBookLibrary.Models;
using Microsoft.EntityFrameworkCore;
namespace _24HackBookLibrary.API
{
    public class BookAPI
    {
        public static void Map(WebApplication app)
        {
            //Get all books
            app.MapGet("/books", (_24HackBookLibraryDbContext db) =>
            {
                var books = db.Books.ToList();

                if (books == null)
                {
                    return Results.NotFound("No books found");
                }
                return Results.Ok(books);
            });

            //Get single book
            app.MapGet("/books/{id}", (_24HackBookLibraryDbContext db, int id) =>
            {
                var book = db.Books.SingleOrDefault(b => b.Id == id);

                if (book == null)
                {
                    return Results.NotFound("Book not found");
                }
                return Results.Ok(book);
            });

            //Delete a book
            app.MapDelete("/books/{id}", (_24HackBookLibraryDbContext db, int id) =>
            {
                var bookToDelete = db.Books.SingleOrDefault(b => b.Id == id);

                if (bookToDelete == null)
                {
                    return Results.NotFound("Book not found");
                }
                db.Books.Remove(bookToDelete);
                db.SaveChanges();
                return Results.Ok("Book successfully deleted");
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
        }
    }
}
