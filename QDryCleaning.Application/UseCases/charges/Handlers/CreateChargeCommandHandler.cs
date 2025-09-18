using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Charges.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Handlers
{
    public class CreateChargeCommandHandler : CommandHandlerBase, IRequestHandler<CreateChargeCommand, ChargeDto>
    {
        public CreateChargeCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<ChargeDto> Handle(CreateChargeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request.Name is null)
                {
                    throw new BadRequestExeption("Name field is required!");
                }

                var charge = await _applicationDbContext.Charges.FirstOrDefaultAsync(u => u.Name == request.Name, cancellationToken);
                if (charge is null)
                {
                    charge = _mapper.Map<Charge>(request);
                    charge.CreatedBy = _currentUserService.UserId;
                    charge.CreatedAt = DateTime.Now;
                    await _applicationDbContext.Charges.AddAsync(charge, cancellationToken);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<ChargeDto>(charge);
                }
                else
                {
                    throw new BadRequestExeption("Charge with this name already exists");
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
