using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemTypes.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.ItemTypes.Handlers
{
    public class CreateItemTypeCommandHandler : CommandHandlerBase, IRequestHandler<CreateItemTypeCommand, ItemTypeDto>
    {
        public CreateItemTypeCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<ItemTypeDto> Handle(CreateItemTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request.Name is null)
                {
                    throw new BadRequestExeption("Name field is required!");
                }

                var itemType = await _applicationDbContext.ItemTypes.FirstOrDefaultAsync(u => u.Name == request.Name, cancellationToken);
                if (itemType is null)
                {
                    itemType = _mapper.Map<ItemType>(request);
                    itemType.CreatedBy = _currentUserService.UserId;
                    itemType.CreatedAt = DateTime.Now;
                    await _applicationDbContext.ItemTypes.AddAsync(itemType, cancellationToken);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<ItemTypeDto>(itemType);
                }
                else
                {
                    throw new BadRequestExeption("ItemType with this name already exists");
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
