using TechStore.API.Filters;

namespace TechStore.API.Configurations
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddandConfigureControllers(this IServiceCollection services) 
        {
            services.AddControllers(options => 
                options.Filters.Add(typeof(APIGlobalExceptionHandler)
            ));
            return services;
        }
    }
}
