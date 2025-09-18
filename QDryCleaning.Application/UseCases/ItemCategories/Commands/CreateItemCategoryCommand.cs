using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemCategories.Commands
{
    public class CreateItemCategoryCommand : IRequest<ItemCategoryDto>
    {
        public required string Name { get; set; }
    }
}
