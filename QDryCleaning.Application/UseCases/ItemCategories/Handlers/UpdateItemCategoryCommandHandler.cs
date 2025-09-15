using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemCategories.Commands;

namespace QDryClean.Application.UseCases.ItemCategories.Handlers
{
    public class UpdateItemCategoryCommandHandler : CommandHandlerBase, IRequestHandler<UpdateItemCategoryCommand, ItemCategoryDto>
    {
        public UpdateItemCategoryCommandHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<ItemCategoryDto> Handle(UpdateItemCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemCategory = await _applicationDbContext.ItemCategories.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (itemCategory is not null)
                {
                    itemCategory.Name = request.Name;
                    _applicationDbContext.ItemCategories.Update(itemCategory);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return new ItemCategoryDto() { Id = itemCategory.Id, Name = itemCategory.Name };
                }
                throw new BadRequestExeption($"Item Category not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
