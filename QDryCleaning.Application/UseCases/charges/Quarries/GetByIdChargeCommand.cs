using MediatR;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Quarries
{
    public class GetByIdChargeCommand : IRequest<Charge>
    {
        public int Id { get; set; }
    }
}
