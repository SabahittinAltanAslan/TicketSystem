using Microsoft.AspNetCore.Mvc;
using IyasBilgiIslem.Business.Interfaces;

namespace IyasBilgiIslem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request.Email, request.Password);
            if (token == null)
                return Unauthorized("Geçersiz e-posta veya şifre.");

            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
