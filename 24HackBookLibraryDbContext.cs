using Microsoft.EntityFrameworkCore;
using _24HackBookLibrary.Models;
public class _24HackBookLibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserBookRating> UserBookRatings { get; set; }

    public _24HackBookLibraryDbContext(DbContextOptions<_24HackBookLibraryDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre { Id = 1, GenreName = "Biography"},
            new Genre { Id = 2, GenreName = "Children's" },
            new Genre { Id = 3, GenreName = "History"},
            new Genre { Id = 4, GenreName = "Fantasy"},
            new Genre { Id = 5, GenreName = "Mystery"},
            new Genre { Id = 6, GenreName = "Science-Fiction"},
            new Genre { Id = 7, GenreName = "Young Adult"}
        });

        modelBuilder.Entity<Author>().HasData(new Author[]
        {
            new Author { Id = 1, Name = "Anne Frank"},
            new Author { Id = 2, Name = "Madeline L'Engle"},
            new Author { Id = 3, Name = "Jack Weatherford"},
            new Author { Id = 4, Name = "Steven Erikson"},
            new Author { Id = 5, Name = "Dan Brown"},
            new Author { Id = 6, Name = "Douglas Adams"},
            new Author { Id = 7, Name = "Suzanne Collins"}
        });

        modelBuilder.Entity<Book>().HasData(new Book[]
        {
            new Book { Id = 1, Title = "The Diary of a Young Girl", BookCover = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1560816565l/48855.jpg", AuthorId = 1, GenreId = 1, PublishYear = 1947},
            new Book { Id = 2, Title = "A Wrinkle in Time", BookCover = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1507963312l/33574273._SX318_.jpg", AuthorId = 2, GenreId = 2, PublishYear = 1962},
            new Book { Id = 3, Title = "Genghis Khan and the Making of the Modern World", BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1530716694i/40718726.jpg", AuthorId = 3, GenreId = 3, PublishYear = 2004},
            new Book { Id = 4, Title = "Gardens of the Moon", BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1548497031i/55399.jpg", AuthorId = 4, GenreId = 4, PublishYear = 1999},
            new Book { Id = 5, Title = "Angels and Demons", BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1696691404i/960.jpg", AuthorId = 5, GenreId = 5, PublishYear = 2000},
            new Book { Id = 6, Title = "The Hitchhiker's Guide to the Galaxy", BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1531891848i/11.jpg", AuthorId = 6, GenreId = 6, PublishYear = 1979},
            new Book { Id = 7, Title = "The Hunger Games", BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1586722975i/2767052.jpg", AuthorId = 7, GenreId = 7, PublishYear = 2008}
        });

        modelBuilder.Entity<Comment>().HasData(new Comment[]
        {
            new Comment { Id = 1, UserId = 1, BookId = 1, DatePosted = new DateTime(2024,01,10,0,0,0,DateTimeKind.Utc), Content = "A very important historical work."},
            new Comment { Id = 2, UserId = 2, BookId = 2, DatePosted = new DateTime(2024,01,15,0,0,0,DateTimeKind.Utc), Content = "Wild and imaginative!"},
            new Comment { Id = 3, UserId = 3, BookId = 3, DatePosted = new DateTime(2024,01,22,0,0,0,DateTimeKind.Utc), Content = "A bit biased but otherwise worth reading."},
            new Comment { Id = 4, UserId = 4, BookId = 4, DatePosted = new DateTime(2024,02,01,0,0,0,DateTimeKind.Utc), Content = "I get the feeling the entire Malazan series will benefit from a reread."},
            new Comment { Id = 5, UserId = 5, BookId = 5, DatePosted = new DateTime(2024,02,12,0,0,0,DateTimeKind.Utc), Content = "The battle between Science and religion is a fascinating topic to read."},
        });

        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User { Id = 1, Uid = "DJNoS94RYXSgpS0jTW7RSVlWyCG3", UserName = "GMarkus", Email = "GregMarkus1992@gmail.com", Bio = "Test", IsAdmin = true},
            new User { Id = 2, Uid = "pVt45Of2j2ThgpcIPKruq1pKn4A2", UserName = "NWelton", Email = "nathopp@gmail.com", Bio = "Test", IsAdmin = true},
            new User { Id = 3, Uid = "udUYrA1rU1huTDv7dIsRYDcdLwl2", UserName = "HSmith", Email = "HSmith@email.com", Bio = "Test", IsAdmin = true},
            new User { Id = 4, Uid = "vaO8Bo1J2SVL7O2grpe1r0Lef9R2", UserName = "DSwann", Email = "mrthincrisp@gmail.com", Bio = "Test", IsAdmin = true},
            new User { Id = 5, Uid = "qNfn30qHHwUki1tCyhS58puS8Ov1", UserName = "BSchnurb", Email = "B33blebroxx@gmail.com", Bio = "Test", IsAdmin = true}
        });

        modelBuilder.Entity<UserBookRating>().HasData(new UserBookRating[]
    {
        new UserBookRating { Id =1, BookId = 2, UserId = 4, Score = 5},
        new UserBookRating { Id =2, BookId = 6, UserId = 18, Score = 5},
        new UserBookRating { Id =3, BookId = 4, UserId = 18, Score = 5},
        new UserBookRating { Id =4, BookId = 3, UserId = 1, Score = 3},
        new UserBookRating { Id =5, BookId = 1, UserId = 2, Score = 4}
    });

        modelBuilder.Entity<UserBookRating>()
            .HasKey(ubr => new { ubr.Id });

        modelBuilder.Entity<UserBookRating>()
            .HasOne(ubr => ubr.User)
            .WithMany(u => u.UserBookRatings)
            .HasForeignKey(ubr => ubr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserBookRating>()
            .HasOne(ubr => ubr.Book)
            .WithMany(b => b.UserBookRatings)
            .HasForeignKey(ubr => ubr.BookId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}

