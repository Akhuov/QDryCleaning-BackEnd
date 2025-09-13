using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.SA.Commands;

namespace QDryClean.Application.UseCases.SA.Handlers
{
    public class UpdateChargeCommandHandler : IRequestHandler<UpdateChargeCommand, ChargeDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        private IMapper _mapper;

        public UpdateChargeCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService,IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<ChargeDto> Handle(UpdateChargeCommand request, CancellationToken cancellationToken)
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
                    return _mapper.Map<ChargeDto>(charge);
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
