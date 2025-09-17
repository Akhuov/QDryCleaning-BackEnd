using QDryClean.Domain.Enums;

namespace QDryClean.Application.Dtos
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public required decimal TotalCost { get; set; }
        public required PaymentStatus PaymentStatus { get; set; }
        public string? Notes { get; set; }
        public decimal Discount { get; set; }
        public int OrderId { get; set; }
    }
}
