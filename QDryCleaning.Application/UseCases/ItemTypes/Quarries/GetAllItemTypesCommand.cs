using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.ItemTypes.Quarries
{
    public class GetAllItemTypesCommand : IRequest<List<ItemTypeDto>>
    {
    }
}
