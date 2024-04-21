namespace OnlyTools.Models
{
    internal class PaginationViewModel
    {
        public object Items { get; set; }
        public object TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}