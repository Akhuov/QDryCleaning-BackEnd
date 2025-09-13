using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Customers.Querries;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class GetByIdCustomerQuerryHandler : CommandHandlerBase, IRequestHandler<GetByIdCustomerQuerry, CustomerDto>
    {
        public GetByIdCustomerQuerryHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<CustomerDto> Handle(GetByIdCustomerQuerry request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                return _mapper.Map<CustomerDto>(customer);

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
