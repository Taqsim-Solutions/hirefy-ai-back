using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class User : Auditable<int>, ISoftDeletable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
