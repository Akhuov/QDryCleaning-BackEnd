using QDryClean.Domain.Enums;

namespace QDryClean.Domain.Entities
{
    public class Order : Auditable
    {
        public required int ReceiptNumber { get; set; }
        public required OrderStatus Status { get; set; }
        public required string ProcessStatus { get; set; }
        public required DateOnly ExpectedCompletionDate { get; set; }
        public required int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public string? Notes { get; set; }
    }
}
