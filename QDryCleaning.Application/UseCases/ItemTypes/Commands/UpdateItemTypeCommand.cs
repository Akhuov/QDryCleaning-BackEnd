using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Commands
{
    public class UpdateItemTypeCommand : ItemTypeDto,IRequest<ItemTypeDto>
    {
        public int Id { get; set; }
    }
}
