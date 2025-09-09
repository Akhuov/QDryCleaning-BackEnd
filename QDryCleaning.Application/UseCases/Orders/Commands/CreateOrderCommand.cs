using MediatR;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public int ReceiptNumber { get; set; }
        public int CustomerId { get; set; }
    }
}
