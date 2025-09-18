using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Orders.Commands;

namespace QDryClean.Application.UseCases.Orders.Handlers
{
    public class DeleteOrderCommandHandler : CommandHandlerBase, IRequestHandler<DeleteOrderCommand, string>
    {
        public DeleteOrderCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (order is not null)
                {
                    _applicationDbContext.Orders.Remove(order);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return $"Order {order.Id} Deleted Succesfully!";
                }
                else
                {
                    throw new BadRequestExeption($"Order with ID {request.Id} not found.");
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
