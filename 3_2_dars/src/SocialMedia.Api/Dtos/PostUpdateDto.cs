namespace SocialMedia.Api.Dtos
{
    public class PostUpdateDto
    {

        public string Content { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }

    }
}
