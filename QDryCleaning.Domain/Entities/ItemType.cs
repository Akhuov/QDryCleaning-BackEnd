namespace QDryClean.Domain.Entities
{
    public class ItemType : Auditable
    {
        public required string Name { get; set; }
        public required int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public required int ChargeId { get; set; }
        public Charge Charge { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
