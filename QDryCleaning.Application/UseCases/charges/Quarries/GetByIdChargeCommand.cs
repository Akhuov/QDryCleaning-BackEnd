using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Quarries
{
    public class GetByIdChargeCommand : IRequest<ChargeDto>
    {
        public int Id { get; set; }
    }
}
