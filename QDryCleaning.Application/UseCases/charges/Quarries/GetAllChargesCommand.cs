using MediatR;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.charges.Quarries
{
    public class GetAllChargesCommand : IRequest<List<Charge>>
    {
    }
}
