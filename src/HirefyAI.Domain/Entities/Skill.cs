using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Skill : Auditable<int>, ISoftDeletable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Resume Resume { get; set; }
        public int ResumeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
