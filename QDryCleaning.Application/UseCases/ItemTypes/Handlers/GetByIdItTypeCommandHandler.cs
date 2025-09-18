using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemTypes.Quarries;

namespace QDryClean.Application.UseCases.ItemTypes.Handlers
{
    public class GetByIdItTypeCommandHandler : CommandHandlerBase, IRequestHandler<GetByIdItemTypeCommand, ItemTypeDto>
    {
        public GetByIdItTypeCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<ItemTypeDto> Handle(GetByIdItemTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemType = await _applicationDbContext.ItemTypes.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                return _mapper.Map<ItemTypeDto>(itemType);

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
