using HirefyAI.Application.DataTransferObjects.Auth;
using HirefyAI.Application.DataTransferObjects.Auth.Google;
using HirefyAI.Application.Services.Helpers;
using HirefyAI.Domain.Entities;
using HirefyAI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace HirefyAI.Application.Services.Auth
{
    public class GoogleClient
    {
        private readonly HirefyAIDb _hirefyAIDb;
        private readonly GoogleOAuthOptions _googleOAuthOptions;
        private readonly JwtSettings _jwtSettings;
        private readonly PasswordHasher _passwordHasher;
        private readonly TokenGenerator _tokenGenerator;

        public GoogleClient(
            IConfiguration configuration,
            PasswordHasher passwordHasher,
            TokenGenerator tokenGenerator,
            HirefyAIDb hirefyAIDb)
        {
            _googleOAuthOptions = configuration.GetSection("GoogleOAuthOptions").Get<GoogleOAuthOptions>();
            _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            _passwordHasher = passwordHasher;
            _hirefyAIDb = hirefyAIDb;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<TokenDto> SignAsync(GoogleDto googleLoginDto)
        {
            Payload payload = new();

            try
            {
                payload = await ValidateAsync(googleLoginDto.IdToken, new ValidationSettings
                {
                    Audience = new[] { _googleOAuthOptions.ClientId }
                });
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException(ex.Message, ex);
            }

            var existingUser = await _hirefyAIDb.Users
                .FirstOrDefaultAsync(u => u.Email == payload.Email);

            TokenDto token = null;

            if (existingUser is not null)
            {
                token = await _tokenGenerator.GenerateTokenAsync(existingUser);
                return token;
            }

            var user = await CreateNewUserAsync(payload);

            token = await _tokenGenerator.GenerateTokenAsync(user);
            return token;
        }

        private async Task<User> CreateNewUserAsync(Payload payload)
        {
            var user = new User
            {
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                Email = payload.Email,
                //ProfilePicture = payload.Picture,
                //LoginProviderSubject = payload.Subject,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpireDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays),
            };

            var entityEntry = await _hirefyAIDb.Users.AddAsync(user);
            await _hirefyAIDb.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}
