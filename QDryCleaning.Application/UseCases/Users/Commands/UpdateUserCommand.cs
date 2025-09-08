using MediatR;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; } 
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string LogIn { get; set; }
        public required string Password { get; set; }
        public required UserRole UserRole { get; set; } = UserRole.Receptionist;// Default role is Receptionist
    }
}
