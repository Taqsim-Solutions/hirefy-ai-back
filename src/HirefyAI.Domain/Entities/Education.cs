using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Education : Auditable<long>, ISoftDeletable
    {
        public string Degree { get; set; }
        public string Institution { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Description { get; set; }
        public Resume Resume { get; set; }
        public int ResumeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
