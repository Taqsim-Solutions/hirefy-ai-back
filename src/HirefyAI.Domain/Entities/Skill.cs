using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Skill : Auditable<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Resume Resume { get; set; }
        public int ResumeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
