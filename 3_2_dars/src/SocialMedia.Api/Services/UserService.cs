using SocialMedia.Api.AppDBContext;
using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services;

public class UserService : IUserService
{
    public bool BlockUser(Guid userId, string token)
    {
        var tokenResult = AppDBContext1.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        foreach (var user in AppDBContext1.Users)
        {
            if (user.UserId == userId)
            {
                user.UserBlocked = !user.UserBlocked;
                return true;
            }
        }
        return false;
    }

    public bool ChangeRole(Guid userId, string newRole, string token)
    {
        var tokenResult = AppDBContext1.GetTokenInfo(token);

        if (tokenResult.role != "SuperAdmin")
        {
            return false;
        }

        foreach (var user in AppDBContext1.Users)
        {
            if (user.UserId == userId)
            {
                user.UserRole = newRole;
                return true;
            }
        }

        return false;
    }

    public bool DeleteUser(Guid userId, string token)
    {
        var tokenResult = AppDBContext1.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        foreach (var user in AppDBContext1.Users)
        {
            if (user.UserId == userId)
            {
                AppDBContext1.Users.Remove(user);
                return true;
            }
        }

        return false;
    }

    public bool DeleteUserPost(Guid postId, string token)
    {
        var tokenResult = AppDBContext1.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        foreach (var post in AppDBContext1.Posts)
        {
            if (post.PostId == postId)
            {
                AppDBContext1.Posts.Remove(post);
                return true;
            }
        }

        return false;
    }

    public List<UserGetDto>? GetAllUsers(string token)
    {
        var tokenResult = AppDBContext1.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return null;
        }

        var users = AppDBContext1.Users;
        var userDtos = new List<UserGetDto>();
        foreach (var user in users)
        {
            var userDto = new UserGetDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                UserRole = user.UserRole,
                UserBlocked = user.UserBlocked,
                RegisterTime = user.RegisterTime
            };
            userDtos.Add(userDto);
        }

        return userDtos;
    }
}

