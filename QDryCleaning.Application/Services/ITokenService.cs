using QDryClean.Domain.Entities;

namespace QDryClean.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
