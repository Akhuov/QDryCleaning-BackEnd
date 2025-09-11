using MediatR;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.charges.Commands
{
    public class CreateChargeCommand : IRequest<Charge>
    {
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public ItemType? ItemType { get; set; }
    }
}
