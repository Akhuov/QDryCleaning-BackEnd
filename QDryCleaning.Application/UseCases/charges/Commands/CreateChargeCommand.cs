using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.SA.Commands
{
    public class CreateChargeCommand : ChargeDto,IRequest<ChargeDto>
    {
    }
}
