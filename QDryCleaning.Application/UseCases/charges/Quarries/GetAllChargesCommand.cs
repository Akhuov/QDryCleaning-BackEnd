using MediatR;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Quarries
{
    public class GetAllChargesCommand : IRequest<List<Charge>>
    {
    }
}
