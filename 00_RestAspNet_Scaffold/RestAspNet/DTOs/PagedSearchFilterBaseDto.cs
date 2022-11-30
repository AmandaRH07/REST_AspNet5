namespace RestAspNet.DTOs
{
    public class PagedSearchFilterBaseDto
    {
        public string SortDirection { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
