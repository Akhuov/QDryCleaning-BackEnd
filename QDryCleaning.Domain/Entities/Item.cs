namespace QDryClean.Domain.Entities
{
    public class Item : Auditable
    {
        public string Colour { get; set; } = null;
        public string BrandName { get; set; } = null;
        public string Description { get; set; } = null;
        public required int ItemTypeId { get; set; }
        public ItemType Type { get; set; }
        public required int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
