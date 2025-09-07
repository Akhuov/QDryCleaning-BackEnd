namespace QDryClean.Domain.Entities
{
    public class ItemCategory : Auditable
    {
        public required string Name { get; set; }
        public ICollection<ItemType> Invoices { get; set; } = new List<ItemType>();
    }
}