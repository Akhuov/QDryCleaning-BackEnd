using AutoMapper;
using MediatR;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Items.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Items.Handlers
{
    public class CreateItemCommandHandler: CommandHandlerBase, IRequestHandler<CreateItemCommand, ItemDto>
    {
        public CreateItemCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<ItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _mapper.Map<Item>(request);
                item.CreatedBy = _currentUserService.UserId;
                item.CreatedAt = DateTime.Now;
                await _applicationDbContext.Items.AddAsync(item, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ItemDto>(item);
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
