
namespace QDryClean.Domain.Entities
{
    public class Charge : Auditable
    {
        public required decimal Cost { get; set; }
        public required string Name { get; set; }
        public ItemType ItemType { get; set; }
    }
}
