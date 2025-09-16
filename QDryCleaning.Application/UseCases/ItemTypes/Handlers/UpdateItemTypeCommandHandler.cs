using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemTypes.Commands;

namespace QDryClean.Application.UseCases.ItemTypes.Handlers
{
    public class UpdateItemTypeCommandHandler : CommandHandlerBase, IRequestHandler<UpdateItemTypeCommand, ItemTypeDto>
    {
        public UpdateItemTypeCommandHandler(
           IApplicationDbContext applicationDbContext,
           ICurrentUserService currentUserService,
           IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<ItemTypeDto> Handle(UpdateItemTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemType = await _applicationDbContext.ItemTypes.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (itemType is not null)
                {
                    itemType.Name = request.Name;
                    itemType.ItemCategoryId = request.ItemCategoryId;
                    itemType.ChargeId = request.ChargeId;
                    itemType.UpdatedAt = DateTime.UtcNow;
                    itemType.UpdatedBy = _currentUserService.UserId;

                    _applicationDbContext.ItemTypes.Update(itemType);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<ItemTypeDto>(itemType);
                }
                throw new BadRequestExeption($"itemType with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
