using QDryClean.Domain.Entities;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.Common.Interfaces.Auth
{
    public interface ITokenService
    {
        string GenerateToken(int id, UserRole role);
    }
}
