using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemCategories.Querries
{
    public class GetByIdItemCategoryQuerry : IRequest<ItemCategoryDto>
    {
        public int Id { get; set; }
    }
}
