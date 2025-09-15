using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemCategories.Commands;

namespace QDryClean.Application.UseCases.ItemCategories.Handlers
{
    public class DeleteItemCategoryCommandHandler : CommandHandlerBase, IRequestHandler<DeleteItemCategoryCommand, string>
    {
        public DeleteItemCategoryCommandHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<string> Handle(DeleteItemCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemCategory = await _applicationDbContext.ItemCategories.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (itemCategory is not null)
                {
                    _applicationDbContext.ItemCategories.Remove(itemCategory);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return $"Item Category {itemCategory.Name} Deleted Succesfully!";
                }
                else
                {
                    throw new BadRequestExeption($"Item Category not found.");
                }
            }
            catch (BadRequestExeption)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
