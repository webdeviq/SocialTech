using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly SocialTechContext _context;
        public PostsController(SocialTechContext context)
        {
            this._context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetAllPosts()
        {
            List<PostDto> postDtos = await _context.Posts.Include(post => post.PostOwner)
            .Select(element => new PostDto
            {
                Category = element.Category.ToString(),
                Description = element.Description,
                Id = element.Id,
                Likes = element.Likes,
                Title = element.Title,
                PostOwner = new UserDto
                {
                    Email = element.PostOwner.Email,
                    FirstName = element.PostOwner.FirstName,
                    LastName = element.PostOwner.LastName,
                    Id = element.PostOwner.Id,
                }
            }).ToListAsync();
            return Ok(postDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetOnePost(int id)
        {
            PostDto postDto = await _context.Posts
                .Include(p => p.PostOwner)
                .Where(result => result.Id == id)
                .Select(element => new PostDto
                {
                    Category = element.Category.ToString(),
                    Description = element.Description,
                    Id = element.Id,
                    Likes = element.Likes,
                    Title = element.Title,

                    PostOwner = new UserDto
                    {
                        Email = element.PostOwner.Email,
                        FirstName = element.PostOwner.FirstName,
                        LastName = element.PostOwner.LastName,
                        Id = element.PostOwner.Id,
                    }
                }).FirstAsync();
            return Ok(postDto);

        }
    }
}