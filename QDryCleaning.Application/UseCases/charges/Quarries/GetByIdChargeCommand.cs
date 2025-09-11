using MediatR;

namespace QDryClean.Application.UseCases.charges.Quarries
{
    public class GetByIdChargeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
