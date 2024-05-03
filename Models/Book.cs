namespace _24HackBookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? BookCover { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PublishYear { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<User>? User { get; set; }

        public ICollection<UserBookRating>? UserBookRatings { get; set; }

    }
}
