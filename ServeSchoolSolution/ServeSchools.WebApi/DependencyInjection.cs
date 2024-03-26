using ServeSchools.WebApi.Controllers.Schools;
using ServeSchools.WebApi.Services;

namespace ServeSchools.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddTransient<ISchoolService, SchoolService>();
            return services;
        }
    }
}
