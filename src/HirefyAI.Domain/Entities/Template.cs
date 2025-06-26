using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Template : Auditable<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public User User { get; set; }
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
