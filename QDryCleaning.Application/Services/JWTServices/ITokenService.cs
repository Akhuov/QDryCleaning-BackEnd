using QDryClean.Domain.Entities;

namespace QDryClean.Application.Services.JWTServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
