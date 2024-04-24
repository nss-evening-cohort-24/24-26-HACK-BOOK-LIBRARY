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
        }
    }
}
