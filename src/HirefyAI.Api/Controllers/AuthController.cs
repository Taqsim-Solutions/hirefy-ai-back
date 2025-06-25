using HirefyAI.Application.DataTransferObjects.Auth;
using HirefyAI.Application.DataTransferObjects.Auth.Google;
using HirefyAI.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace HirefyAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly GoogleClient _googleClient;
        private readonly IAuthService _authService;

        public AuthController(GoogleClient googleClient, IAuthService authService)
        {
            _googleClient = googleClient;
            _authService = authService;
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> LoginWithGoogleAccountAsync(GoogleDto googleLoginDto)
        {
            var token = await _googleClient.SignAsync(googleLoginDto);

            return Ok(token);
        }

        [HttpPost("login-email")]
        public async Task<IActionResult> LoginWithEmailAsync(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);

            return Ok(token);
        }
    }
}
