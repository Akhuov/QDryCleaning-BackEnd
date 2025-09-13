using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Customers.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class CreateCustomerCommandHandler: CommandHandlerBase, IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        public CreateCustomerCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request.FirstName is null || request.PhoneNumber is null)
                {
                    throw new BadRequestExeption("First Name and Phone Number fields are required!");
                }

                var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber, cancellationToken);
                if (customer is null)
                {
                    customer = _mapper.Map<Customer>(request);
                    customer.CreatedBy = _currentUserService.UserId;
                    customer.CreatedAt = DateTime.Now;
                    await _applicationDbContext.Customers.AddAsync(customer, cancellationToken);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<CustomerDto>(customer);
                }
                else
                {
                    throw new BadRequestExeption("Customer with this phone number already exists");
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
