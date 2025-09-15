using MediatR;

namespace QDryClean.Application.UseCases.ItemCategories.Commands
{
    public class DeleteItemCategoryCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
