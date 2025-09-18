using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<OrderDto>
    {
        public int Id { get; set; } 
        public required ProcessStatus ProcessStatus { get; set; }
        public int CustomerId { get; set; }
        public string? Notes { get; set; }
    }
}
