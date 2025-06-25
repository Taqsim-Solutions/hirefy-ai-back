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
        [HttpPost("google-login")]
        public async Task<IActionResult> LoginWithGoogleAccountAsync(GoogleDto googleLoginDto)
        {
            var token = await _googleClient.SignAsync(googleLoginDto);

            return Ok(token);
        }
    }
}
