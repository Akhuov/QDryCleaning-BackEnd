using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemCategories.Commands
{
    public class UpdateItemCategoryCommand : ItemCategoryDto, IRequest<ItemCategoryDto>{ }
}
