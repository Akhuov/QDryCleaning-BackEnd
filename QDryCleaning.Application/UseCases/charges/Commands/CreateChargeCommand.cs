using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Charges.Commands
{
    public class CreateChargeCommand : ChargeDto,IRequest<ChargeDto>
    {
    }
}
