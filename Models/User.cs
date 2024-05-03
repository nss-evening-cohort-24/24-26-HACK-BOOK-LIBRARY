namespace _24HackBookLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<UserBookRating>? UserBookRatings { get; set; }
    }
}
