using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Items.Querries
{
    public class GetAllItemsQuerry: IRequest<List<ItemDto>> { }
}
