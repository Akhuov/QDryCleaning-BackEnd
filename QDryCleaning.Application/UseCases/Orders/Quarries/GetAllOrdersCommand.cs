using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Orders.Quarries
{
    public class GetAllOrdersCommand : IRequest<List<OrderDto>>
    {
    }
}
