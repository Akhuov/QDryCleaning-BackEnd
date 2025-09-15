using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemCategories.Querries;

namespace QDryClean.Application.UseCases.ItemCategories.Handlers
{
    public class GetAllItemCategoriesQuerryHandler : CommandHandlerBase, IRequestHandler<GetAllItemCategoriesQuerry, List<ItemCategoryDto>>
    {
        public GetAllItemCategoriesQuerryHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<List<ItemCategoryDto>> Handle(GetAllItemCategoriesQuerry request, CancellationToken cancellationToken)
        {
            try
            {
                var itemCategories = await _applicationDbContext.ItemCategories.ToListAsync();

                var list_of_itemCategoryDtos = new List<ItemCategoryDto>();
                foreach (var itemCategory in itemCategories)
                {
                    list_of_itemCategoryDtos.Add(new ItemCategoryDto() { 
                        Id = itemCategory.Id, 
                        Name = itemCategory.Name});
                }

                return list_of_itemCategoryDtos;

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
