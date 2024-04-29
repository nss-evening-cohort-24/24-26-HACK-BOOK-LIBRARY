namespace _24HackBookLibrary.API
{
    public static class GenreAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/genres", (_24HackBookLibraryDbContext db) =>
            {
                return db.Genres.ToList();
            });

            //Get single genre by id
            app.MapGet("/genres/{id}", (_24HackBookLibraryDbContext db, int id) =>
            {
                var genre = db.Genres.FirstOrDefault(g => g.Id == id);
                if (genre == null)
                {
                    return Results.NotFound("Genre not found");
                }

                return Results.Ok(genre);
            });
        }
    }
}
