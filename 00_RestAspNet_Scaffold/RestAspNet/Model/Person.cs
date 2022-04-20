using RestAspNet.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        public string First_Name { get; set; }
        [Column("last_name")]
        public string Last_Name { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
