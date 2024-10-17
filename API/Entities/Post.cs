using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public string UserId { get; set; } = string.Empty;
        public User PostOwner { get; set; } = null!;

        public int Likes { get; set; }
        // Post date
        public DateTime PostDate { get; set; }
        // One post can have many answers!
        public ICollection<PostAnswer> Answers { get; set; } = [];
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        
    
    }
}