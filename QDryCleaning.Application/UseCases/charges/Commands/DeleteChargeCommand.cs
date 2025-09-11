using MediatR;

namespace QDryClean.Application.UseCases.charges.Commands
{
    public class DeleteChargeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
