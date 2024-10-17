using System.Security.Claims;
using Api.Dtos.Post;
using API.Data;
using API.Dtos;
using API.Dtos.Auth;
using API.Dtos.Post;
using API.Entities;
using API.Extensions;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly SocialTechContext _socialTechContext;
        public AccountController(UserManager<User> userManager, TokenService tokenService, SocialTechContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _socialTechContext = context;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserPostDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null || user.UserName == null || !await _userManager.CheckPasswordAsync(user, loginDto.PassWord))
            {
                return Unauthorized();
            }


            return new UserPostDto
            {
                Posts = await RetrieveAllPosts(loginDto.UserName),
                Email = user.Email!,
                UserName = user.UserName,

                Token = await _tokenService.GenerateToken(user),
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDto registerDto)
        {
            var newUser = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };
            var result = await _userManager.CreateAsync(newUser, registerDto.PassWord);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }
            await _userManager.AddToRoleAsync(newUser, "Member");
            return StatusCode(201);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetOne(int id)
        {


            var post = await FindPostAsync(id);

            if (post == false) return NotFound(new ProblemDetails { Title = "Requested post does not exist." });
            var userPost = await _socialTechContext.Posts.FindAsync(id);
            PostDto result = DtoMapper.MapGetOnePost(userPost!);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UserPostDto>> GetCurrentUser()
        {

            if (await DoesAUserExist() == false || IsUserAuthenticated() == false) return Unauthorized();
            var user = await _userManager.GetUserAsync(new ClaimsPrincipal(User));
            if (user == null || user.Email == null || user.UserName == null) return Unauthorized();

            return new UserPostDto
            {
                Email = user.Email,
                Posts = await RetrieveAllPosts(user.UserName),
                Token = await _tokenService.GenerateToken(user),
                UserName = user.UserName,
            };

        }

        [Authorize]
        [HttpPost("createpost")]
        public async Task<ActionResult> CreatePost(CreatePostDto createPostDto)
        {
            var userAuthenticated = IsUserAuthenticated();
            if (!userAuthenticated == false || await DoesAUserExist() == false) return Unauthorized();
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            var user = await _userManager.FindByNameAsync(createPostDto.UserName);
            if (user == null)
            {
                return BadRequest($"No user with username {createPostDto}");
            }
            var userId= user.Id;
            Post confirmedPost = DtoMapper.MapCreatePostDto(createPostDto, userId);
            await _socialTechContext.Posts.AddAsync(confirmedPost);

            var postsSaved = await _socialTechContext.SaveChangesAsync();


            if (postsSaved > 0)
            {
                return StatusCode(201);
            }
            return BadRequest("Error creating a new post.");
        }
        private async Task<List<PostDto>> RetrieveAllPosts(string userName)
        {
            var userPosts = await _socialTechContext.Posts.Where(p => p.PostOwner.UserName == userName).ToListAsync();
            return DtoMapper.MapGetAllPosts(userPosts);
        }
        private bool IsUserAuthenticated()
        {

            var isUserAuthenticated = User.Identity?.IsAuthenticated ?? false;
            if (!isUserAuthenticated) return false;
            return true;
        }
        private async Task<bool> DoesAUserExist()
        {
            var result = await _userManager.GetUserAsync(new ClaimsPrincipal(User));
            if (result != null) return true;
            return false;
        }
        private async Task<bool> FindPostAsync(int id)
        {
            var result = await _socialTechContext.Posts.FindAsync(id);
            if (result != null) return true;
            return false;
        }
    }
}