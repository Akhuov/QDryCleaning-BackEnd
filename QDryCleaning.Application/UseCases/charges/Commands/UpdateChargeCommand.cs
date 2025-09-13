using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.SA.Commands
{
    public class UpdateChargeCommand : ChargeDto,IRequest<ChargeDto>
    {
        public int Id { get; set; }
    }
}
