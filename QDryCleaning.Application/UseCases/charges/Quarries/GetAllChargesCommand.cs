using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Quarries
{
    public class GetAllChargesCommand : IRequest<List<ChargeDto>>
    {
    }
}
