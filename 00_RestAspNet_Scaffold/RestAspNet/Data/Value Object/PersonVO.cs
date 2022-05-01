using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet.Data.Converter.Value_Object
{
    [Table("person")]
    public class PersonVO
    {
        public long Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
