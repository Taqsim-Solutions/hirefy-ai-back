using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Experience : Auditable<int>, ISoftDeletable
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Summary { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Resume Resume { get; set; }
        public int ResumeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
