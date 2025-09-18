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
    public class GetAllItemsQuerryHandler : CommandHandlerBase, IRequestHandler<GetAllItemsQuerry, List<ItemDto>>
    {
        public GetAllItemsQuerryHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<List<ItemDto>> Handle(GetAllItemsQuerry request, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _applicationDbContext.Items.ToListAsync();

                var list_of_itemDtos = new List<ItemDto>();
                foreach (var item in items)
                {
                    list_of_itemDtos.Add(_mapper.Map<ItemDto>(item));
                }

                return list_of_itemDtos;

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
