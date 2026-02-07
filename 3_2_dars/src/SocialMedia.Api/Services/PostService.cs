using Microsoft.Extensions.Hosting;
using SocialMedia.Api.AppDBContext;
using SocialMedia.Api.Dtos;
using SocialMedia.Api.Entities;
using System.Text.Json;

namespace SocialMedia.Api.Services;
public class PostService : IPostService
{
    private List<Post> Posts;

    private readonly string FilePath;

    public PostService()
    {
        FilePath = "D:\\MyCodes\\DotNet\\Moduls\\UchinchiModul\\3_2_dars\\src\\SocialMedia.Api\\AppDBContext\\Data.json";
        Posts = new List<Post>();

        //if (!File.Exists(FilePath))
        //{
        //    File.Create(FilePath).Close();
        //}
    }

    public Guid CreatePost(PostCreateDto postCreateDto)
    {
        ReadPostsFromFile();
        Post post = new Post()
        {
            PostId = Guid.NewGuid(),
            Title = postCreateDto.Title,
            Content = postCreateDto.Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserId = postCreateDto.UserId
        };

        Posts.Add(post);
        SavePostsToFile();
        return post.PostId;
    }

    public bool DeletePost(Guid postId, string token)
    {
        ReadPostsFromFile();
        var tokenResult = AppDBContext1.GetTokenInfo(token);
        foreach (var post in Posts)
        {
            if (post.PostId == postId && post.UserId.ToString() == tokenResult.userId)
            {
                Posts.Remove(post);
                SavePostsToFile();
                return true;
            }
        }

        return false;
    }

    public List<PostGetDto> GetAllPosts()
    {
        ReadPostsFromFile();
        List<PostGetDto> postGetDtos = new List<PostGetDto>();
        foreach (var p in Posts)
        {
            postGetDtos.Add(new PostGetDto()
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                UserId = p.UserId
            });
        }

        return postGetDtos;
    }

    public PostGetDto GetPostById(Guid postId)
    {
        ReadPostsFromFile();
        foreach (var p in Posts)
        {
            if (p.PostId == postId)
            {
                return new PostGetDto()
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    UserId = p.UserId
                };
            }
        }

        return null;
    }



    public bool UpdatePost(Guid postId, PostUpdateDto postUpdateDto, string token)
    {

        ReadPostsFromFile();
        var tokenResult = AppDBContext1.GetTokenInfo(token);

        foreach (var p in Posts)
        {
            if (p.PostId == postId && p.UserId.ToString() == tokenResult.userId)
            {
                p.Title = postUpdateDto.Title;
                p.Content = postUpdateDto.Content;
                p.UpdatedAt = DateTime.UtcNow;
                SavePostsToFile();
                return true;
            }
        }

        return false;
    }

    private void SavePostsToFile()
    {
        var DataJson = JsonSerializer.Serialize(Posts);
        File.WriteAllText(FilePath, DataJson);
    }

    private void ReadPostsFromFile()
    {
        var json = File.ReadAllText(FilePath);

        if (string.IsNullOrEmpty(json))
        {
            Posts = new List<Post>();
            return;
        }

        Posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
    }

    public List<PostGetDto>? GetAllPostsByAdmin(string token)
    {
        var tokenResult = AppDBContext1.GetTokenInfo(token);
        if (tokenResult.role == "User")
        {
            return null;
        }

        var postGetDtos = new List<PostGetDto>();
        foreach (var post in AppDBContext1.Posts)
        {
            var postGetDto = new PostGetDto()
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
            };
            postGetDtos.Add(postGetDto);
        }

        return postGetDtos;
    }
}

