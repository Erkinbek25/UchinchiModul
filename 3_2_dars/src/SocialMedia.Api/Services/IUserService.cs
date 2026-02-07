using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services
{
    public interface IUserService
    {
        public List<UserGetDto>? GetAllUsers(string token);
        public bool DeleteUser(Guid userId, string token);
        public bool DeleteUserPost(Guid postId, string token);
        public bool BlockUser(Guid userId, string token);
        public bool ChangeRole(Guid userId, string newRole, string token);

    }
}