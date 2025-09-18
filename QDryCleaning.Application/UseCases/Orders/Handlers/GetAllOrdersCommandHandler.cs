using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Orders.Quarries;

namespace QDryClean.Application.UseCases.Orders.Handlers
{
    public class GetAllOrdersCommandHandler : CommandHandlerBase, IRequestHandler<GetAllOrdersCommand, List<OrderDto>>
    {
        public GetAllOrdersCommandHandler(
           IApplicationDbContext applicationDbContext,
           ICurrentUserService currentUserService,
           IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<List<OrderDto>> Handle(GetAllOrdersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _applicationDbContext.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Invoice)
                    .Include(o => o.Items)
                    .ToListAsync();

                var list_of_orderDtos = new List<OrderDto>();
                foreach (var invoice in orders)
                {
                    list_of_orderDtos.Add(_mapper.Map<OrderDto>(invoice));
                }

                return list_of_orderDtos;

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
