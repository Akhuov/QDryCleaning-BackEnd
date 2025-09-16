using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Quarries
{
    public class GetAllUsersCommand : IRequest<List<UserDto>>
    {
    }
}
