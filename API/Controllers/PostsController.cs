using API.Data;
using API.Dtos;
using API.Dtos.Post;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class PostsController(SocialTechContext context) : BaseApiController
    {

        private readonly SocialTechContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetAllPosts([FromQuery] PostParams postParams)
        {

            var query = _context.Posts
            .Include(p => p.Category)
            .Sort(postParams.OrderBy)
            .Search(postParams.SearchTerm)
            .Filter(postParams.Categories)
            .AsQueryable();

            var postsResult = await PagedList<Post>.ToPagedList(query, postParams.PageNumber,
            postParams.PageSize);
            Response.AddPaginationHeader(postsResult.MetaData);
            return postsResult.MapGetAllPosts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetOnePost(int id)
        {
            Post? post = await FindAsync(id);
            if (post == null) return NotFound(new ProblemDetails { Title = "Requested post does not exist" });
            PostDto result = DtoMapper.MapGetOnePost(post);
            return Ok(result);
        }


        private async Task<Post> FindAsync(int postId)
        {
            Post? result = await _context.Posts.Include(p => p.PostOwner).Where(p => p.Id == postId).FirstOrDefaultAsync();
            if (result != null) return result;
            return null!;
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            List<string> categories = await _context.Posts.
            Select(element => element.Category.CategoryName).Distinct().ToListAsync();
            return Ok(new { categories });
        }
    }
}