

namespace API.Dtos.Post
{
    /// <summary>
    /// A DTO used to retireve all Posts from this API and send back to the client.
    /// </summary>
    public class PostDto 
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public UserPostInfoDto  ? PostOwner { get; set; } = new();
        public DateTime UploadedOn { get; set; }

        public int Likes { get; set; }
        public string Category { get; set; } = string.Empty;
        public List<PostAnswerDto>? PostAnswers { get; set; }
    }
}