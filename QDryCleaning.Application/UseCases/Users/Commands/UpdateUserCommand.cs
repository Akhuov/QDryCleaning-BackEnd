using MediatR;
using QDryClean.Application.Dtos;
using QDryClean.Domain.Entities;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : UserDto, IRequest<UserDto> { }
}
