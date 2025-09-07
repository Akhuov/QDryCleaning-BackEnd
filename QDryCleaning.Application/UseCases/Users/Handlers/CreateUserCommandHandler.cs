using MediatR;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Users.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    LogIn = request.LogIn,
                    Password = request.Password,
                    UserRole = request.UserRole
                };
                await _applicationDbContext.Users.AddAsync(user, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
