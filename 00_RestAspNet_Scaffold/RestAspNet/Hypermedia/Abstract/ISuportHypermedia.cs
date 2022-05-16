using System.Collections.Generic;

namespace RestAspNet.Hypermedia.Abstract
{
    public interface ISuportHypermedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
