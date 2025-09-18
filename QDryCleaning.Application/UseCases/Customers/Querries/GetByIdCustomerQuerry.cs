using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Querries
{
    public class GetByIdCustomerQuerry: IRequest<CustomerDto> 
    {
        public int Id { get; set; }
    }
}
