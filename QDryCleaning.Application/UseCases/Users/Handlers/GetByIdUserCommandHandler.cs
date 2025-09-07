using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Users.Quarries;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Handlers
{
    public class GetByIdUserCommandHandler : IRequestHandler<GetByIdUserCommand, User>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (user is not null)
                {
                    return user;
                }
                return new User();
            }
            catch (Exception)
            {
                return new User();
            }
        }
    }
}
