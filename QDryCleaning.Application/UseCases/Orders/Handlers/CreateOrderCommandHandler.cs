using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Orders.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Orders.Handlers
{
    public class CreateOrderCommandHandler : CommandHandlerBase, IRequestHandler<CreateOrderCommand, OrderDto>
    {
        public CreateOrderCommandHandler(
           IApplicationDbContext applicationDbContext,
           ICurrentUserService currentUserService,
           IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (order is null)
                {
                    order = _mapper.Map<Order>(request);
                    await _applicationDbContext.Orders.AddAsync(order, cancellationToken);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<OrderDto>(order);
                }
                else
                {
                    throw new BadRequestExeption("Order with this id already exists");
                }
            }
            catch (BadRequestExeption)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
