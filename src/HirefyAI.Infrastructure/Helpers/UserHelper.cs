using HirefyAI.Domain.Entities;

namespace HirefyAI.Infrastructure.Helpers
{
    public class UserHelper
    {
        private readonly HirefyAIDb _hirefyAIDb;

        public UserHelper(HirefyAIDb hirefyAIDb)
        {
            _hirefyAIDb = hirefyAIDb;
        }

        public async Task<int> UserId(string email)
        {
            var user = _hirefyAIDb.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return user.Id;
            }

            user = new User()
            {
                Email = email,
                FirstName = "New",
                LastName = "User"
            };

            var entry = await _hirefyAIDb.Users.AddAsync(user);
            await _hirefyAIDb.SaveChangesAsync();

            return entry.Entity.Id;
        }
    }
}
