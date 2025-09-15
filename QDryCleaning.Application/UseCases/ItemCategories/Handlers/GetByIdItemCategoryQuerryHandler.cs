using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemCategories.Querries;

namespace QDryClean.Application.UseCases.ItemCategories.Handlers
{
    public class GetByIdItemCategoryQuerryHandler : CommandHandlerBase, IRequestHandler<GetByIdItemCategoryQuerry, ItemCategoryDto>
    {
        public GetByIdItemCategoryQuerryHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<ItemCategoryDto> Handle(GetByIdItemCategoryQuerry request, CancellationToken cancellationToken)
        {
            try
            {
                var itemCategory = await _applicationDbContext.ItemCategories.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (itemCategory is null)
                {
                    return null;
                }
                return new ItemCategoryDto() { Id = itemCategory.Id, Name = itemCategory.Name };

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
