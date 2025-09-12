using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Customers.Commands
{
    public class CreateCustomerCommand : CustomerDto, IRequest<CustomerDto> { }
}
