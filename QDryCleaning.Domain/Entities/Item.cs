namespace QDryClean.Domain.Entities
{
    public class Item : Auditable
    {
        public string? Colour { get; set; }
        public string? BrandName { get; set; }
        public string? Description { get; set; }
        public int ItemTypeId { get; set; }
        public ItemType Type { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
