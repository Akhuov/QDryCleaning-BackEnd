using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public required ProcessStatus ProcessStatus { get; set; }
        public required DateOnly ExpectedCompletionDate { get; set; }
        public int CustomerId { get; set; }
        public string? Notes { get; set; }
    }
}
