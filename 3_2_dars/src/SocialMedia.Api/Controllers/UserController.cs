using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos;
using SocialMedia.Api.Services;

namespace SocialMedia.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController()
        {
           UserService = new UserService();
        }

        [HttpPost("create")]
        public Guid Create(PostCreateDto postCreateDto)
        {
            var postId = PostService.CreatePost(postCreateDto);
            return postId;
        }

        [HttpGet("get-all")]
        public List<PostGetDto> GetAll()
        {
            return PostService.GetAllPosts();
        }

        [HttpGet("get-by-id")]
        public PostGetDto? GetById(Guid postId)
        {
            return PostService.GetPostById(postId);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid postId, string token)
        {
            return PostService.DeletePost(postId, token);
        }

        [HttpPut("update")]
        public bool Update(Guid postId, PostUpdateDto postUpdateDto, string token)
        {
            return PostService.UpdatePost(postId, postUpdateDto, token);
        }

    }
}
