using QDryClean.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDryClean.Application.Dtos.UserDTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LogIn { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Receptionist;// Default role is Receptionist
    }
}
