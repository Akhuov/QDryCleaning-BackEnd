using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Infrastructure.Persistance;
using QDryClean.Infrastructure.Services;

namespace QDryClean.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}