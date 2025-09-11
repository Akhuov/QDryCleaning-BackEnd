using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Users.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        public UpdateUserCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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
                    user.UpdatedAt = DateTime.UtcNow;
                    user.UpdatedBy = _currentUserService.UserId;

                    _applicationDbContext.Users.Update(user);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return user;
                }
                throw new BadRequestExeption($"User with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
