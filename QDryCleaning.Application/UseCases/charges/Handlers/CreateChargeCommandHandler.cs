using MediatR;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.charges.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.charges.Handlers
{
    public class CreateChargeCommandHandler : IRequestHandler<CreateChargeCommand, Charge>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;

        public CreateChargeCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }
        public async Task<Charge> Handle(CreateChargeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var charge = new Charge()
                {
                    Cost = request.Cost,
                    Name = request.Name,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = _currentUserService.UserId,
                };
                await _applicationDbContext.Charges.AddAsync(charge, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return charge;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
