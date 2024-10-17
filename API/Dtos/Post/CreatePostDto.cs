using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Post
{
    /// <summary>
    /// A DTO used for Creating a new Post (HTTP Post).
    /// </summary>
    public class CreatePostDto
    {
        [Required(ErrorMessage = "A Title Is Required.")]
        [StringLength(150, ErrorMessage ="Title can't be more than 150")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage="A description is required.")]
        
        public string Description { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
        public int CategoryId { get; set; }
        public string UserName { get; set; } = string.Empty;
        // public string UserName { get; set; } = string.Empty;




    }
}