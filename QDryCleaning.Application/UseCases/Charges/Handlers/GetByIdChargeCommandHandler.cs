using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.charges.Quarries;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Handlers
{
    public class GetByIdChargeCommandHandler : IRequestHandler<GetByIdChargeCommand, Charge>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdChargeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Charge> Handle(GetByIdChargeCommand request, CancellationToken cancellationToken)
        {
            var charge = await _applicationDbContext.Charges.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (charge is not null)
                return charge;
            throw new BadRequestExeption($"User with ID {request.Id} not found.");
        }
    }
}
