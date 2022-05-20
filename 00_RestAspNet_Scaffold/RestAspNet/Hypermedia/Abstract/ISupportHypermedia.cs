using System.Collections.Generic;

namespace RestAspNet.Hypermedia.Abstract
{
    public interface ISupportHypermedia
    {
        List<HypermediaLink> Links { get; set; }
    }
}
