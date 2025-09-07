
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;

namespace QDryClean.Application.Services.JWTServices
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(IApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.LogIn == login);
            if (user is null)
            {
                throw new UnauthorizedAccessException("Invalid login.");
            }
            if (user.Password != password)
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }

            return _tokenService.GenerateToken(user.Id, user.UserRole);
        }
    }
}
