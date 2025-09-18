using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Charges.Quarries;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Charges.Handlers
{
    public class GetByIdChargeCommandHandler : CommandHandlerBase,IRequestHandler<GetByIdChargeCommand, ChargeDto>
    {
        public GetByIdChargeCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<ChargeDto> Handle(GetByIdChargeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var charge = await _applicationDbContext.Charges.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                return _mapper.Map<ChargeDto>(charge);

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
