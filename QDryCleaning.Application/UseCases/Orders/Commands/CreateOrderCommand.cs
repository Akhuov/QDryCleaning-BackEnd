using MediatR;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
