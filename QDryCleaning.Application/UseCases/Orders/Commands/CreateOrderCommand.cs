using MediatR;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public int ReceiptNumber { get; set; }
        public int CustomerId { get; set; }
    }
}
