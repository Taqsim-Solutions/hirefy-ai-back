using HirefyAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HirefyAI.Infrastructure
{
    public partial class HirefyAIDb : DbContext
    {
        // tables
        public DbSet<Book> Books { get; set; }
    }
}
