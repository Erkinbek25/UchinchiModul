namespace SocialMedia.Api.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string?  Content { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User? User { get; set; }
        public Guid UserId { get; set; }
    }
}   
