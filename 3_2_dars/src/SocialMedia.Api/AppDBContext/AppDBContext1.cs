using SocialMedia.Api.Entities;

namespace SocialMedia.Api.AppDBContext;

public class AppDBContext1
{
    public static List<User> Users { get; set; }
    public static List<Post> Posts { get; set; }

    static AppDBContext1()
    {
        Users = new List<User>();
        Posts = new List<Post>();
    }

    public static (string userId, string role) GetTokenInfo(string token)
    {
        var userId = token.Substring(0, 26);
        var role = token.Substring(26);
        return (userId, role);
    }

    private static void DataSeed()
    {
        // USER 1
        var user1 = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = "Akobir",
            LastName = "Abduvahobov",
            UserName = "Akobir_1229",
            Password = "1234",
            UserRole = "SuperAdmin",
            UserBlocked = false,
            RegisterTime = DateTime.Now
        };
        Users.Add(user1);

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Akobir Post 1",
            Content = "Content of post 1",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user1.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Akobir Post 2",
            Content = "Content of post 2",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user1.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Akobir Post 3",
            Content = "Content of post 3",
            CreatedAt = DateTime.Now,
            UpdatedAt= DateTime.Now,
            UserId = user1.UserId
        });


        // USER 2
        var user2 = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            UserName = "johndoe",
            Password = "password123",
            UserRole = "User",
            UserBlocked = false,
            RegisterTime = DateTime.Now
        };
        Users.Add(user2);

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "John Post 1",
            Content = "John content 1",
            CreatedAt= DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user2.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "John Post 2",
            Content = "John content 2",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user2.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "John Post 3",
            Content = "John content 3",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user2.UserId
        });


        // USER 3
        var user3 = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = "Smith",
            UserName = "janesmith",
            Password = "password456",
            UserRole = "User",
            UserBlocked = false,
            RegisterTime = DateTime.Now
        };
        Users.Add(user3);

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Jane Post 1",
            Content = "Jane content 1",
            CreatedAt= DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user3.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Jane Post 2",
            Content = "Jane content 2",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user3.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Jane Post 3",
            Content = "Jane content 3",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user3.UserId
        });


        // USER 4
        var user4 = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = "Abror",
            LastName = "Odilov",
            UserName = "Abror_2005",
            Password = "1234",
            UserRole = "Admin",
            UserBlocked = false,
            RegisterTime = DateTime.Now
        };
        Users.Add(user4);

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Abror Post 1",
            Content = "Abror content 1",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user4.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Abror Post 2",
            Content = "Abror content 2",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user4.UserId
        });

        Posts.Add(new Post
        {
            PostId = Guid.NewGuid(),
            Title = "Abror Post 3",
            Content = "Abror content 3",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user4.UserId
        });
    }
}

