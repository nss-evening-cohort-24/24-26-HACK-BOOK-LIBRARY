namespace _24HackBookLibrary.Models
{
    public class CommentsDTO
    {
        public int Id { get; set; } 
        public string? Content { get; set; }
        public DateTime? DatePosted { get; set; }
        public string? CommentsUserName { get; set; }
        public int CommentsUserId { get; set; }

    }
}
