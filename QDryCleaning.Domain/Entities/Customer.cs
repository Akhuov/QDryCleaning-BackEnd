namespace QDryClean.Domain.Entities
{
    public class Customer : Auditable
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public decimal Points { get; set; }
    }
}
