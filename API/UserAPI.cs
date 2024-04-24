using Microsoft.EntityFrameworkCore;
using _24HackBookLibrary.Models;

namespace _24HackBookLibrary.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            //Check User
            app.MapGet("/checkUser/{uid}", (_24HackBookLibraryDbContext db, string uid) =>
            {
                var user = db.Users.SingleOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound("User not registered");
                }

                return Results.Ok(user);
            });

            //Register User
            app.MapPost("/users/register", (_24HackBookLibraryDbContext db, User newUser) =>
            {
                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to register user");
                }
            });

            //View User's Details
            app.MapGet("/users/{id}", (_24HackBookLibraryDbContext db, int id) =>
            {
                var user = db.Users.Find(id);

                if (user == null)
                {
                    return Results.NotFound("No user found");
                }

                return Results.Ok(user);
            });


        }
    }
}
