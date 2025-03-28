namespace Movies.Contracts.Requests
{
    public class PaginationParams
    {
        public int PageNumber { get; set; }

        public int PageSize 
        { 
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        private int _pageSize = 5;
        private const int MaxPageSize = 30;
    }
}
