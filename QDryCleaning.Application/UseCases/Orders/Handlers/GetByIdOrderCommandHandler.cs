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
    public class GetByIdOrderCommandHandler : CommandHandlerBase, IRequestHandler<GetByIdOrderCommand, OrderDto>
    {
        public GetByIdOrderCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<OrderDto> Handle(GetByIdOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                return _mapper.Map<OrderDto>(order);

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
