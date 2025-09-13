using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Charges.Quarries;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Handlers
{
    public class GetAllChargesCommandHandler : IRequestHandler<GetAllChargesCommand, List<Charge>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllChargesCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Charge>> Handle(GetAllChargesCommand request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Charges.ToListAsync(cancellationToken);
        }
    }
}
