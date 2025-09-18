using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Customers.Commands;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class UpdateCustomerCommandHandler: CommandHandlerBase, IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        public UpdateCustomerCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (customer is not null)
                {
                    customer.FirstName = request.FirstName;
                    customer.LastName = request.LastName;
                    customer.PhoneNumber = request.PhoneNumber;
                    customer.AdditionalPhoneNumber = request.AdditionalPhoneNumber;
                    customer.Points = request.Points;
                    customer.UpdatedAt = DateTime.Now;
                    customer.UpdatedBy = _currentUserService.UserId;

                    _applicationDbContext.Customers.Update(customer);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<CustomerDto>(customer);
                }
                throw new BadRequestExeption($"Customer with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
