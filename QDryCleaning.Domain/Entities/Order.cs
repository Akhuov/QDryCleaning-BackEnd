using QDryClean.Domain.Enums;

namespace QDryClean.Domain.Entities
{
    public class Order : Auditable
    {
        public int ReceiptNumber { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; } 
        //public OrderStatus Status { get; set; }
        //public ICollection<Item> Items { get; set; } = new List<Item>();
        //public OrderCharge OrderCharge { get; set; }
    }
}
