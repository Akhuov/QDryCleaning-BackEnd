using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemCategories.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.ItemCategories.Handlers
{
    public class CreateItemTypeCommandHandler : CommandHandlerBase, IRequestHandler<CreateItemCategoryCommand, ItemCategoryDto>
    {
        public CreateItemTypeCommandHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper){ }

        public async Task<ItemCategoryDto> Handle(CreateItemCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request.Name is null)
                {
                    throw new BadRequestExeption("Name field is required!");
                }

                var itemCategory = await _applicationDbContext.ItemCategories.FirstOrDefaultAsync(u => u.Name == request.Name, cancellationToken);
                if (itemCategory is null)
                {
                    itemCategory = new ItemCategory() { 
                        Name = request.Name,
                        CreatedBy = _currentUserService.UserId,
                        CreatedAt = DateTime.Now
                    };
                    await _applicationDbContext.ItemCategories.AddAsync(itemCategory, cancellationToken);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return new ItemCategoryDto() { Id = itemCategory.Id, Name = itemCategory.Name };
                }
                else
                {
                    throw new BadRequestExeption("Item Category with this name already exists");
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
