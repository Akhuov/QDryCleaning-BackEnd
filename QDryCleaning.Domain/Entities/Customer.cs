namespace QDryClean.Domain.Entities
{
    public class Customer : Auditable
    {
        public required string FirstName { get; set; }
        public string LastName { get; set; } = null;
        public required string PhoneNumber { get; set; }
        public string AdditionalPhoneNumber { get; set; } = null;
        public decimal Points { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
