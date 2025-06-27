using HirefyAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HirefyAI.Infrastructure.Configurations
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasData(new List<Template>
            {
                new Template
                {
                    Id = 1,
                    Name = "Default Template",
                    Description = "This is the default template for resumes.",
                    Created = DateTime.UtcNow,
                    CreatedBy = "System",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "System",
                    UserId = 1
                }
            });
        }
    }
}
