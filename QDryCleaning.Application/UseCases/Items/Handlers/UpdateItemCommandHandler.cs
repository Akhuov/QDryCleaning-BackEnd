using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Items.Commands;

namespace QDryClean.Application.UseCases.Items.Handlers
{
    public class UpdateItemCommandHandler : CommandHandlerBase, IRequestHandler<UpdateItemCommand, ItemDto>
    {
        public UpdateItemCommandHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<ItemDto> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = await _applicationDbContext.Items.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (item is not null)
                {
                    item.Colour = request.Colour;
                    item.Description = request.Description;
                    item.BrandName = request.BrandName;
                    item.UpdatedBy = _currentUserService.UserId;
                    item.UpdatedAt = DateTime.Now;

                    _applicationDbContext.Items.Update(item);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<ItemDto>(item);
                }
                throw new BadRequestExeption($"Item with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
