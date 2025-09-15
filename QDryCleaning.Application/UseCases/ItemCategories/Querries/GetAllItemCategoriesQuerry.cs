using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemCategories.Querries
{
    public class GetAllItemCategoriesQuerry : IRequest<List<ItemCategoryDto>>{ }
}
