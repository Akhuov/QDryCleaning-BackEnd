using MediatR;

namespace QDryClean.Application.UseCases.ItemTypes.Commands
{
    public class DeleteItemTypeCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
