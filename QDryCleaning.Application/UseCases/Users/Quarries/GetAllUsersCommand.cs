using MediatR;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Quarries
{
    public class GetAllUsersCommand : IRequest<List<User>>
    {
    }
}
