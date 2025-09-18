using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Orders.Quarries
{
    public class GetByIdOrderCommand : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
