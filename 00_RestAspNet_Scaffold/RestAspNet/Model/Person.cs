using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet.Model
{
    [Table("person")]
    public class Person
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("First_Name")]
        public string First_Name { get; set; }
        [Column("Last_Name")]
        public string Last_Name { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
    }
}
