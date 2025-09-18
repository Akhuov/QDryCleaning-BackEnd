using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Items.Querries
{
    public class GetByIdItemQuerry : IRequest<ItemDto>
    {
        public int Id { get; set; }
    }
}
