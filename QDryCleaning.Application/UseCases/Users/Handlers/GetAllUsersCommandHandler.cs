using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Users.Quarries;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Handlers
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<User>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllUsersCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Users.ToListAsync(cancellationToken);
        }
    }
}
