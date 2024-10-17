namespace API.Dtos
{
    /// <summary>
    /// A DTO used to accept an answer for a Post fromt the Client.
    /// </summary>
    public class PostAcceptAnswerDto
    {
        public int PostId { get; set; }
        public int AnswerId { get; set; }

    }
}