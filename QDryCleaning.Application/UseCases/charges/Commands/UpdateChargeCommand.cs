using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Commands
{
    public class UpdateChargeCommand : ChargeDto,IRequest<ChargeDto> { }
}
