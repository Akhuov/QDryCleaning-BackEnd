using QDryClean.Domain.Enums;

namespace QDryClean.Domain.Entities
{
    public class User : Auditable
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string LogIn { get; set; }
        public required string Password { get; set; }
        public required UserRole UserRole { get; set; } = UserRole.Receptionist;// Default role is Receptionist
    }
}
