using MediatR;

namespace QDryClean.Application.UseCases.Charges.Commands
{
    public class DeleteChargeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
