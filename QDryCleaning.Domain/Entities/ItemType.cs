namespace QDryClean.Domain.Entities
{
    public class ItemType : Auditable
    {
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public Charge Charge { get; set; }
    }
}
