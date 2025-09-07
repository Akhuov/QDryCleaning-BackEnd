using QDryClean.Domain.Entities;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.Services.JWTServices
{
    public interface ITokenService
    {
        string GenerateToken(int id, UserRole role);
    }
}
