namespace _24HackBookLibrary.Models
{
    public class UserBookRating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public double Score { get; set; }

        public User? User { get; set; }
        public Book? Book { get; set; }
    }
}
