namespace QDryClean.Domain.Entities
{
    public class Item : Auditable
    {
        public int ItemTypeId { get; set; }
        public ItemType Type { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
