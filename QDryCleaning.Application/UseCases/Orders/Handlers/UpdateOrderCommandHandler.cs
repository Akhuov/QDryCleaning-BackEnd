using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Orders.Commands;

namespace QDryClean.Application.UseCases.Orders.Handlers
{
    public class UpdateOrderCommandHandler : CommandHandlerBase, IRequestHandler<UpdateOrderCommand, OrderDto>
    {
        public UpdateOrderCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (order is not null)
                {
                    order.ProcessStatus = request.ProcessStatus;
                    order.CustomerId = request.CustomerId;
                    order.Notes = request.Notes;
                    order.UpdatedBy = _currentUserService.UserId;
                    order.UpdatedAt = DateTime.Now;

                    _applicationDbContext.Orders.Update(order);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<OrderDto>(order);
                }
                throw new BadRequestExeption($"Order with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
