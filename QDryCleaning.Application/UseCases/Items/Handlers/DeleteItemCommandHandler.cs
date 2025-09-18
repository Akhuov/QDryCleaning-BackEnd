using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Items.Commands;

namespace QDryClean.Application.UseCases.Items.Handlers
{
    public class DeleteItemCommandHandler : CommandHandlerBase, IRequestHandler<DeleteItemCommand, string>
    {
        public DeleteItemCommandHandler(
            IApplicationDbContext applicationDbContext, 
            ICurrentUserService currentUserService, 
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) {  }

        public async Task<string> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = await _applicationDbContext.Items.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (item is not null)
                {
                    _applicationDbContext.Items.Remove(item);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return $"Item {item.BrandName} Deleted Succesfully!";
                }
                else
                {
                    throw new BadRequestExeption($"Item with ID {request.Id} not found.");
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
