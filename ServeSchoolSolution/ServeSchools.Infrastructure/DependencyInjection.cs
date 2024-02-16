using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServeSchools.Application.UnitOfWorks;
using ServeSchools.Domain.Common;
using ServeSchools.Domain.Repositories;
using ServeSchools.Domain.Schools;
using ServeSchools.Infrastructure.Data.DbContexts;
using ServeSchools.Infrastructure.Repositories;

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
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            return services;
        }
    }
}
