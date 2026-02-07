namespace SocialMedia.Api.Dtos
{
    public class UserGetDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public bool UserBlocked { get; set; }
        public DateTime RegisterTime { get; set; }
    }
}
