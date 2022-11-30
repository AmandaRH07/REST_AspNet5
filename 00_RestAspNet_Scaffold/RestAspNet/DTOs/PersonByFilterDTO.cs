using RestAspNet.Hypermedia.Utils;

namespace RestAspNet.DTOs
{
    public class PersonByFilterDto : PagedSearchFilterBaseDto
    {
        public string Name { get; set; }
    }
}
