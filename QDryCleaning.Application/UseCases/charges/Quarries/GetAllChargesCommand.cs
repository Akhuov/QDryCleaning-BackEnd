using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.charges.Quarries
{
    public class GetAllChargesCommand : IRequest<List<Charge>>
    {
    }
}
