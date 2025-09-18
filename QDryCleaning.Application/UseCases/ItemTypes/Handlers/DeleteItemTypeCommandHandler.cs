using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.ItemTypes.Commands;

namespace QDryClean.Application.UseCases.ItemTypes.Handlers
{
    public class DeleteItemTypeCommandHandler : CommandHandlerBase, IRequestHandler<DeleteItemTypeCommand, string>
    {
        public DeleteItemTypeCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<string> Handle(DeleteItemTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemType = await _applicationDbContext.ItemTypes.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (itemType is not null)
                {
                    _applicationDbContext.ItemTypes.Remove(itemType);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return $"itemType {itemType.Name} Deleted Succesfully!";
                }
                else
                {
                    throw new BadRequestExeption($"itemType with ID {request.Id} not found.");
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
