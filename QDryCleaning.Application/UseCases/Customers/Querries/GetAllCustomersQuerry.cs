using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Querries
{
    public class GetAllCustomersQuerry : IRequest<List<CustomerDto>> { }
}
