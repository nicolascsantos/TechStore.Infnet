using Microsoft.EntityFrameworkCore;
using TechStore.Data;

namespace TechStore.API.Configurations
{
    public static class DatabaseServiceConfiguration
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TechStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")
            ));
            return services;
        }
    }
}
