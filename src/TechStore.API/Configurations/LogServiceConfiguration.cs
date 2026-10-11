using Serilog;
using Serilog.Events;

namespace TechStore.API.Configurations
{
    public static class LogServiceConfiguration
    {
        public static IServiceCollection AddLogs(this IServiceCollection services)
        {
            services.AddSerilog((servicos, logger) =>
            {
                logger
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console();

                var caminhoAzure = Environment.GetEnvironmentVariable("HOME");

                if (!string.IsNullOrWhiteSpace(caminhoAzure) &&
                    !string.IsNullOrWhiteSpace(
                        Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME")))
                {
                    logger.WriteTo.File(
                        Path.Combine(caminhoAzure, "LogFiles", "techstore-.log"),
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 7,
                        fileSizeLimitBytes: 10 * 1024 * 1024,
                        rollOnFileSizeLimit: true,
                        shared: true);
                }
            });

            return services;
        }
    }
}
