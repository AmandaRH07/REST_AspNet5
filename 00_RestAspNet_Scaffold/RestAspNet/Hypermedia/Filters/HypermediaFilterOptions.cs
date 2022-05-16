using RestAspNet.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestAspNet.Hypermedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
