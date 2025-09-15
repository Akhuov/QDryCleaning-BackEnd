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
    public class GetAllChargesCommandHandler : CommandHandlerBase, IRequestHandler<GetAllChargesCommand, List<ChargeDto>>
    {
        public GetAllChargesCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<List<ChargeDto>> Handle(GetAllChargesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var charges = await _applicationDbContext.Charges.ToListAsync();

                var list_of_chargesDtos = new List<ChargeDto>();
                foreach (var customer in charges)
                {
                    list_of_chargesDtos.Add(_mapper.Map<ChargeDto>(charges));
                }

                return list_of_chargesDtos;

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
