
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class PostAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public DateTime AnswerDate { get; set; }
        public bool AnswerAccepted { get; set; } = false;
        public DateTime? AnswerAcceptedDate { get; set; }
        public Post Post { get; set; } = new();
        [ForeignKey("PostId")]
        public int PostId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User AnsweredBy { get; set; } = null!;
    }
}