using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class User : Auditable<int>, ISoftDeletable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();
        public ICollection<Template> Templates { get; set; } = new List<Template>();
    }
}
