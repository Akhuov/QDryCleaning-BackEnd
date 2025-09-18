using QDryClean.Domain.Enums;

namespace QDryClean.Domain.Entities
{
    public class Order : Auditable
    {
        public int ReceiptNumber { get; set; }
        public required ProcessStatus ProcessStatus { get; set; }
        public required DateOnly ExpectedCompletionDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }
        public string? Notes { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
