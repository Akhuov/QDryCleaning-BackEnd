using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.charges.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.charges.Handlers
{
    public class UpdateChargeCommandHandler : IRequestHandler<UpdateChargeCommand, Charge>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;

        public UpdateChargeCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }

        public async Task<Charge> Handle(UpdateChargeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var charge = await _applicationDbContext.Charges.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (charge is not null)
                {
                    charge.Cost = request.Cost;
                    charge.Name = request.Name;
                    charge.UpdatedAt = DateTime.UtcNow;
                    charge.UpdatedBy = _currentUserService.UserId;

                    _applicationDbContext.Charges.Update(charge);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return charge;
                }
                throw new BadRequestExeption($"User with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
