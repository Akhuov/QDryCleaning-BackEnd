using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Commands
{
    public class CreateItemTypeCommand : ItemTypeDto,IRequest<ItemTypeDto>
    {
    }
}
