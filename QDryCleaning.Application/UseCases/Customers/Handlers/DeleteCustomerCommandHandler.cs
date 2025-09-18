using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Customers.Commands;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class DeleteCustomerCommandHandler : CommandHandlerBase, IRequestHandler<DeleteCustomerCommand, string>
    {
        public DeleteCustomerCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (customer is not null)
                {
                    _applicationDbContext.Customers.Remove(customer);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return $"Customer {customer.FirstName} Deleted Succesfully!";
                }
                else
                {
                    throw new BadRequestExeption($"Customer with ID {request.Id} not found.");
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
