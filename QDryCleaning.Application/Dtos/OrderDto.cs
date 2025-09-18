
using QDryClean.Domain.Entities;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; } 
        public required int ReceiptNumber { get; set; }
        public required ProcessStatus ProcessStatus { get; set; }
        public required DateOnly ExpectedCompletionDate { get; set; }
        public int CustomerId { get; set; }
        public string? Notes { get; set; }
    }
}
