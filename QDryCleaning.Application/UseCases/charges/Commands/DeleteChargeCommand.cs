using MediatR;

namespace QDryClean.Application.UseCases.Charges.Commands
{
    public class DeleteChargeCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
