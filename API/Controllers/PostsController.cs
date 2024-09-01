using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class PostsController : BaseApiController
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
                Category = element.Category.CategoryEnum.ToString(),
                Description = element.Description,
                Id = element.Id,
                Likes = element.Likes,
                Title = element.Title,
                UploadedOn = element.PostDate,
                PostOwner = new UserDto
                {
                    Email = element.PostOwner.Email,
                    FirstName = element.PostOwner.FirstName,
                    LastName = element.PostOwner.LastName,
                    Id = element.PostOwner.Id,
                },
                PostAnswers = element.Answers.Select((answer) => new PostAnswerDto
                {
                    Id = answer.Id,
                    Answer = answer.Answer,
                    AnswerAccepted = answer.AnswerAccepted,
                    AnswerDate = answer.AnswerDate,
                    AnswerAcceptedDate = answer.AnswerAcceptedDate,
                    AnsweredBy = answer.AnsweredBy.FirstName + ' ' + answer.AnsweredBy.LastName,
                    PostId = element.Id,
                }).ToList(),
            }).ToListAsync();
            return Ok(postDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetOnePost(int id)
        {
             Post? post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            PostDto postDto = await _context.Posts
                .Include(p => p.PostOwner)
                .Where(result => result.Id == id)
                .Select(element => new PostDto
                {
                    Category = element.Category.CategoryEnum.ToString(),
                    Description = element.Description,
                    Id = element.Id,
                    Likes = element.Likes,
                    Title = element.Title,
                    UploadedOn = element.PostDate,
                    PostOwner = new UserDto
                    {
                        Email = element.PostOwner.Email,
                        FirstName = element.PostOwner.FirstName,
                        LastName = element.PostOwner.LastName,
                        Id = element.PostOwner.Id,
                    },
                    PostAnswers = element.Answers.Select((answer) => new PostAnswerDto
                    {
                        Id = answer.Id,
                        Answer = answer.Answer,
                        AnswerAccepted = answer.AnswerAccepted,
                        AnswerDate = answer.AnswerDate,
                        AnsweredBy = answer.AnsweredBy.FirstName + ' ' + answer.AnsweredBy.LastName,
                        PostId = element.Id,

                    }).ToList(),
                }).FirstAsync();
            return Ok(postDto);

        }
    }
}