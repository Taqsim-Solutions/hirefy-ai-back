using HirefyAI.Domain.Common;
using HirefyAI.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HirefyAI.Infrastructure
{
    public partial class HirefyAIDb
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HirefyAIDb(IHttpContextAccessor httpContextAccessor,DbContextOptions<HirefyAIDb> _options)
            : base(_options)
            => _httpContextAccessor = httpContextAccessor;

        /// <summary>
        /// Save all changes with auditable information.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var entries = ChangeTracker
                    .Entries()
                    .Where(e =>
                        e.State == EntityState.Added || e.State == EntityState.Modified)
                    .Where(e => e.Entity.GetType().IsSubclassOfRawGeneric(typeof(Auditable<>)));

                foreach (var entry in entries)
                {
                    dynamic auditableEntity = entry.Entity;

                    if (entry.State == EntityState.Added)
                    {
                        auditableEntity.Created = DateTime.UtcNow;
                        auditableEntity.CreatedBy = GetUserId();
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        auditableEntity.LastModified = DateTime.UtcNow;
                        auditableEntity.LastModifiedBy = GetUserId();
                    }
                }

                return await base.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get current user id from HttpContext.
        /// </summary>
        /// <returns></returns>
        private string GetUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext is null)
                return "System";

            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userId ?? "System";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations for entities
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HirefyAIDb).Assembly);
        }
    }
}
