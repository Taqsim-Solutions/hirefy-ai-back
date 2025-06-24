using Microsoft.Extensions.DependencyInjection;

namespace HirefyAI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<HirefyAIDb>();

            return services;
        }
    }
}
