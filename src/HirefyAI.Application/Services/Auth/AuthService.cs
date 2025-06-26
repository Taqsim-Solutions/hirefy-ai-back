using Common.ServiceAttribute;
using HirefyAI.Application.DataTransferObjects.Auth;
using HirefyAI.Application.Helpers;
using HirefyAI.Domain.Entities;
using HirefyAI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HirefyAI.Application.Services.Auth
{
    [ScopedService]
    public class AuthService : IAuthService
    {
        private readonly HirefyAIDb _hirefyAIDb;
        private readonly TokenGenerator _tokenGenerator;

        public AuthService(HirefyAIDb hirefyAIDb, TokenGenerator tokenGenerator)
        {
            _hirefyAIDb = hirefyAIDb;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _hirefyAIDb.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if(user is null)
            {
                user = new User()
                {
                    Email = loginDto.Email,
                    FirstName = loginDto.Email,
                    RefreshToken = Guid.NewGuid().ToString(),
                    RefreshTokenExpireDate = DateTime.UtcNow.AddDays(7)
                };

                var entry = await _hirefyAIDb.Users.AddAsync(user);
                await _hirefyAIDb.SaveChangesAsync();
                
                return await _tokenGenerator.GenerateTokenAsync(entry.Entity);
            }

            return await _tokenGenerator.GenerateTokenAsync(user);
        }
    }
}
