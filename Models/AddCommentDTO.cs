namespace _24HackBookLibrary.Models
{
    public class AddCommentDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string? Content { get; set; }
    }
}
