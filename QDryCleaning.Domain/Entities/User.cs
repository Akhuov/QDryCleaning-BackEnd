using QDryClean.Domain.Enums;

namespace QDryClean.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LogIn { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Receptionist;// Default role is Receptionist
    }
}
