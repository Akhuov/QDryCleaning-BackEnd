using MediatR;

namespace QDryClean.Application.UseCases.charges.Commands
{
    public class UpdateChargeCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public int? ItemTypeId { get; set; }
    }
}
