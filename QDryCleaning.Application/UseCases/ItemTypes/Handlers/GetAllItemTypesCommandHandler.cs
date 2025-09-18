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
    public class GetAllItemTypesCommandHandler : CommandHandlerBase, IRequestHandler<GetAllItemTypesCommand, List<ItemTypeDto>>
    {
        public GetAllItemTypesCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<List<ItemTypeDto>> Handle(GetAllItemTypesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemTypes = await _applicationDbContext.ItemTypes.ToListAsync();

                var list_of_itemTypeDtos = new List<ItemTypeDto>();
                foreach (var itemType in itemTypes)
                {
                    list_of_itemTypeDtos.Add(_mapper.Map<ItemTypeDto>(itemType));
                }

                return list_of_itemTypeDtos;

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
