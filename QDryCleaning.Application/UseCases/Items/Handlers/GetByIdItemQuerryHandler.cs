using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Items.Querries;

namespace QDryClean.Application.UseCases.Items.Handlers
{
    internal class GetByIdItemQuerryHandler : CommandHandlerBase, IRequestHandler<GetByIdItemQuerry, ItemDto>
    {
        public GetByIdItemQuerryHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) {  }

        public async Task<ItemDto> Handle(GetByIdItemQuerry request, CancellationToken cancellationToken)
        {
            try
            {
                var item = await _applicationDbContext.Items.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                return _mapper.Map<ItemDto>(item);

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
