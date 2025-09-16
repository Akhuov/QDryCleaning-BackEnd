using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Quarries
{
    public class GetByIdItemTypeCommand : IRequest<ItemTypeDto>
    {
        public int Id { get; set; }
    }
}
