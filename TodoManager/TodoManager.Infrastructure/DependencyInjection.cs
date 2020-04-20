using Microsoft.Extensions.DependencyInjection;
using TodoManager.Application.Common.Interfaces;
using TodoManager.Infrastructure.Persistance;
using TodoManager.Infrastructure.Services;

namespace TodoManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IDateTime, ApplicationDateTime>();
            services.AddTransient<IHashService, HashService>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
