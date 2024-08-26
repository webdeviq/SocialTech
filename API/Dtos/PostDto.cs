using API.Models;

namespace API.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public UserDto PostOwner { get; set; } = null!;


        public int Likes { get; set; }
        public string Category { get; set; } = string.Empty;

    }
}