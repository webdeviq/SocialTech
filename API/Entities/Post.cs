using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models;

namespace API.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public User PostOwner { get; set; } = null!;
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public int Likes { get; set; }
        public CategoryEnum Category { get; set; }
    }
}