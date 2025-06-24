using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Resume : Auditable<int>, ISoftDeletable
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
