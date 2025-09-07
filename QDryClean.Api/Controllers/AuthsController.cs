using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Dtos.AuthDTOs;
using QDryClean.Application.Services.JWTServices;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;
        public AuthsController(IApplicationDbContext context, ITokenService tokenService, IAuthService authService)
        {
            _context = context;
            _tokenService = tokenService;
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromForm] AuthDTO dto)
        {
            try
            {
                var authService = new AuthService(_context, _tokenService);
                var token = await _authService.LoginAsync(dto.LogIn, dto.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
