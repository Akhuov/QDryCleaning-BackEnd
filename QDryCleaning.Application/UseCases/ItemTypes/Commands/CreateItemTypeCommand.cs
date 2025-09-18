using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Commands
{
    public class CreateItemTypeCommand : IRequest<ItemTypeDto>
    {
        public required string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public int ChargeId { get; set; }
    }
}
