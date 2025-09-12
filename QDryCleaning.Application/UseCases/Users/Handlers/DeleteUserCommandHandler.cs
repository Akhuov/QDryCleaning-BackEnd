using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Users.Commands;

namespace QDryClean.Application.UseCases.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (user is not null)
                {
                    _applicationDbContext.Users.Remove(user);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
