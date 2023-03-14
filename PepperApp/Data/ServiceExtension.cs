using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PepperApp.Repositories;

namespace PepperApp.Data.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PepperContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("LibraryConnectionString"));
            });
            services.AddScoped<IPepperRepository, PepperRepository>();

            return services;
        }
    }
}
