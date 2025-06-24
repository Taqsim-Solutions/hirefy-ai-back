using HirefyAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HirefyAI.Infrastructure
{
    public partial class HirefyAIDb : DbContext
    {
        // tables
        public DbSet<User> Users { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
    }
}
