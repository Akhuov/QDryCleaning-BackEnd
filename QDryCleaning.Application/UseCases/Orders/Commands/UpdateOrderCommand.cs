using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class UpdateOrderCommand : OrderDto, IRequest<OrderDto>
    {
    }
}
