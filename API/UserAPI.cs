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
                var user = db.Users.FirstOrDefault(u => u.Uid == uid);

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

            //Edit User Details
            app.MapPut("/users/{id}", (_24HackBookLibraryDbContext db, int id, User user) =>
            {
                var userBeingUpdated = db.Users.FirstOrDefault(u => u.Id == id);

                if (userBeingUpdated == null)
                {
                    return Results.NotFound("No user found");
                }

                userBeingUpdated.Uid = user.Uid;
                userBeingUpdated.UserName = user.UserName;
                userBeingUpdated.Email = user.Email;
                userBeingUpdated.Bio = user.Bio;
                db.SaveChanges();
                return Results.Ok("User has been updated");
            });
            // Check if a user is an admin
            app.MapGet("/users/{id}/isadmin", (_24HackBookLibraryDbContext db, int id) =>
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }

                return Results.Ok(new { IsAdmin = user.IsAdmin });
            });

            // Make a user an admin
            app.MapPut("/users/{id}/makeadmin", (_24HackBookLibraryDbContext db, int id) =>
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }

                user.IsAdmin = true;
                db.SaveChanges();
                return Results.Ok($"User {user.UserName} is now an admin.");
            });
            // Get All Users
            app.MapGet("/users", (_24HackBookLibraryDbContext db) =>
            {
                var users = db.Users.ToList();
                return Results.Ok(users.Select(user => new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    IsAdmin = user.IsAdmin
                }));
            });

        }
    }
}
