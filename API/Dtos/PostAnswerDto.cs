
namespace API.Dtos{ 
    public class PostAnswerDto {
        
        public int Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public DateTime AnswerDate { get; set; }
        public bool AnswerAccepted { get; set; } = false;
        public DateTime ? AnswerAcceptedDate { get; set; }
        
        public int PostId { get; set; } = new();
        public string AnsweredBy { get; set; } = string.Empty;
        
    }

}