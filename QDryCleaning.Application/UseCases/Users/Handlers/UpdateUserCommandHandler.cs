using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Users.Commands;

namespace QDryClean.Application.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (user is not null)
                {
                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                    user.LogIn = request.LogIn;
                    user.Password = request.Password;
                    user.UserRole = request.UserRole;

                    _applicationDbContext.Users.Update(user);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
