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
    public class GetAllCustomersQuerryHandler : CommandHandlerBase, IRequestHandler<GetAllCustomersQuerry, List<CustomerDto>>
    {
        public GetAllCustomersQuerryHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuerry request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _applicationDbContext.Customers.ToListAsync();

                var list_of_customerDtos = new List<CustomerDto>();
                foreach (var customer in customers)
                {
                    list_of_customerDtos.Add(_mapper.Map<CustomerDto>(customer));
                }

                return list_of_customerDtos;

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
