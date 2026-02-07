using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services
{
    public interface IPostService
    {
        List<PostGetDto> GetAllPosts();
        PostGetDto GetPostById(Guid postId);
        public List<PostGetDto>? GetAllPostsByAdmin(string token);
        Guid  CreatePost(PostCreateDto postCreateDto);
        bool UpdatePost(Guid postId, PostUpdateDto postUpdateDto, string token);
        bool DeletePost(Guid postId, string token);

    }
}