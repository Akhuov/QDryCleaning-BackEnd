using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : OrderDto, IRequest<OrderDto>
    {
    }
}
