namespace QDryClean.Domain.Entities
{
    public class OrderCharge : Auditable
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<Charge> Charges { get; set; } = new List<Charge>();
    }
}
