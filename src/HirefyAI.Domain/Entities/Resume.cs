using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Resume : Auditable<int>, ISoftDeletable
    {
        public string Name { get; set; } = string.Empty;

        public Template Template { get; set; }
        public int TemplateId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
