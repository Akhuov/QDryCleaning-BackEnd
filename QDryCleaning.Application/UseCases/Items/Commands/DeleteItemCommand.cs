using MediatR;

namespace QDryClean.Application.UseCases.Items.Commands
{
    public class DeleteItemCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
