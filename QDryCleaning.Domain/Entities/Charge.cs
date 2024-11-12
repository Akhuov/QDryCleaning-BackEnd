
namespace QDryClean.Domain.Entities
{
    public class Charge : BaseModel
    {
        public decimal Price { get; set; }
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

    }
}
