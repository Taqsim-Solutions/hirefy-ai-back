using HirefyAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HirefyAI.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Email).IsUnique();

            // Todo: Configurationdan olishi kerak
            builder.HasData(new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "sardorstudent0618@gmail.com",
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpireDate = DateTime.UtcNow,
            });
        }
    }
}
