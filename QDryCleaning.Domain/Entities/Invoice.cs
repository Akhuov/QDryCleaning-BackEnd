using QDryClean.Domain.Enums;

namespace QDryClean.Domain.Entities
{
    public class Invoice : BaseModel
    {
        public required decimal TotalCost { get; set; }
        public required PaymentStatus PaymentStatus { get; set; }
        public string? Notes { get; set; }
        public decimal? Discount { get; set; }
        public required int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
