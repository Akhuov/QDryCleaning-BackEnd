using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Charges.Commands;

namespace QDryClean.Application.UseCases.Charges.Handlers
{
    public class DeleteChargeCommandHandler : CommandHandlerBase,IRequestHandler<DeleteChargeCommand, string>
    {
        public DeleteChargeCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<string> Handle(DeleteChargeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var charge = await _applicationDbContext.Charges.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (charge is not null)
                {
                    _applicationDbContext.Charges.Remove(charge);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return $"Charge {charge.Name} Deleted Succesfully!";
                }
                else
                {
                    throw new BadRequestExeption($"Charge with ID {request.Id} not found.");
                }
            }
            catch (BadRequestExeption)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
