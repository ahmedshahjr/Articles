namespace Consumer.Models
{
    public class CustomerData
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilNumber { get; set; }
    }
}
