namespace RestAspNet.DTOs
{
    public class BooksByFilterDto : PagedSearchFilterBaseDto
    {
        public string Title { get; set; }
    }
}
