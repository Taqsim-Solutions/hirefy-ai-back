using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class User : Auditable<int>, ISoftDeletable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public ICollection<Template> Templates { get; set; } = new List<Template>();
    }
}
