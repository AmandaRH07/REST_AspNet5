using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet.Data.Converter.Value_Object
{
    [Table("book")]
    public class BookVO
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
