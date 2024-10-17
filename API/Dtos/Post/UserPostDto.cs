using System.ComponentModel.DataAnnotations;
using API.Dtos.Post;

namespace Api.Dtos.Post

{
    /// <summary>
    ///  A DTO to send back when a user is logged in with a valid Token.
    /// </summary>
    public class UserPostDto
    {
        
    
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public List<PostDto> Posts { get; set; } = [];

    }
}