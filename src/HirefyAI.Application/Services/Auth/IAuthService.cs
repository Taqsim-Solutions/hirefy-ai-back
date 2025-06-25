using HirefyAI.Application.DataTransferObjects.Auth;

namespace HirefyAI.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto loginDto);
    }
}
