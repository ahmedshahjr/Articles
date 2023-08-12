using System.ComponentModel.DataAnnotations;

namespace Service1.Models
{
    public class Customer: CustomerInsert
    {
     
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
    }
    public class CustomerInsert
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilNumber { get; set; }
    }
}
