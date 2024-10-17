namespace API.RequestHelpers
{
    public class PostParams : PaginationParams
    {
        public string OrderBy { get; set; } = string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;


    }
}