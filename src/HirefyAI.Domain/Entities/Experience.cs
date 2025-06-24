using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Experience : Auditable<int>, ISoftDeletable
    {
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
