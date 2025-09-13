using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Charges.Commands;

namespace QDryClean.Application.UseCases.Charges.Handlers
{
    public class DeleteChargeCommandHandler : IRequestHandler<DeleteChargeCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteChargeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteChargeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var charge = await _applicationDbContext.Charges.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (charge is not null)
                {
                    _applicationDbContext.Charges.Remove(charge);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
