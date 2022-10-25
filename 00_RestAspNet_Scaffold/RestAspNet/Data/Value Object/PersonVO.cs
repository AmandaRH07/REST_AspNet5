using RestAspNet.Hypermedia;
using RestAspNet.Hypermedia.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet.Data.Converter.Value_Object
{
    [Table("person")]
    public class PersonVO : ISupportHypermedia
    {
        public long Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool Enabled { get; set; }
        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();
    }
}
