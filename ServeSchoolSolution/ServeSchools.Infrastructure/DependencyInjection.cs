using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServeSchools.Application.Common;
using ServeSchools.Infrastructure.Data.DbContexts;

namespace ServeSchools.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ServeSchoolConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IAppliationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            return services;
        }
    }
}
