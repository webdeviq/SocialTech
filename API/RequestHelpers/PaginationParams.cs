namespace API.RequestHelpers
{
    public class PaginationParams
    {

        private const int MaximumPageSize = 50;

        public int PageNumber { get; set; } = 1;
        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaximumPageSize ? MaximumPageSize : value;

        }

    }
}