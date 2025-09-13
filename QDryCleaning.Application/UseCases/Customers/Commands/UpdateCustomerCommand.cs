using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Commands
{
    public class UpdateCustomerCommand: CustomerDto, IRequest<CustomerDto>
    {
        public int Id {  get; set; }
    }
}
