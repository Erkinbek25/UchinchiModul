using SocialMedia.Api.AppDBContext;
using SocialMedia.Api.Dtos;
using SocialMedia.Api.Entities;


namespace SocialMedia.Api.Services;

public class AuthService : IAuthService
{
    public string LoginUser(UserLoginDto userLoginDto)
    {
        foreach (var user in AppDBContext1.Users)
        {
            if (user.UserName == userLoginDto.UserName
                && user.Password == userLoginDto.Password)
            {
                return user.UserId.ToString() + user.UserRole;
            }
        }

        return "User yoki parol xato";
    }

    public Guid RegisterUser(UserRegisterDto userRegisterDto)
    {
        var user = new User()
        {
            UserId = Guid.NewGuid(),
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            UserName = userRegisterDto.UserName,
            Password = userRegisterDto.Password,
            UserRole = "User",
            UserBlocked = false,
            RegisterTime = DateTime.Now
        };

        AppDBContext1.Users.Add(user);

        return user.UserId;
    }
}

