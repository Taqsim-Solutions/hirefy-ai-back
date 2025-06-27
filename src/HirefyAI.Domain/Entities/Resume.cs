using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Resume : Auditable<int>, ISoftDeletable
    {
        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Summary { get; set; }

        public Template Template { get; set; }
        public int TemplateId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }

        public string? Skills { get; set; }
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
