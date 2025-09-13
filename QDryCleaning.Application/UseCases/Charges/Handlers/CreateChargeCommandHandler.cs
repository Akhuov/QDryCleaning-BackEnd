using AutoMapper;
using MediatR;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Charges.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Handlers
{
    public class CreateChargeCommandHandler : IRequestHandler<CreateChargeCommand, ChargeDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        private IMapper _mapper;
        public CreateChargeCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<ChargeDto> Handle(CreateChargeCommand request, CancellationToken cancellationToken)
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
                return _mapper.Map<ChargeDto>(charge);
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
