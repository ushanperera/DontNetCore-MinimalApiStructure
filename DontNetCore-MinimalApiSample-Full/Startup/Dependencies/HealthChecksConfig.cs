using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace DontNetCore_MinimalApiStructure.Startup.Dependencies
{
    public static class HealthChecksConfig
    {
        //Dependency
        public static void AddAllHealthChecks(this IServiceCollection services)
        {
            // Add health checks
            services.AddHealthChecks()
                .AddCheck<HealthChecks.ApiHealthCheck>("API Health Check", tags: ["API"]) //Tags are not mandetory
                .AddCheck<HealthChecks.RandomHealthCheck>("Random Health Check", tags: ["Random"]);
        }

        //Middleware
        public static void UseAppHealthChecks(this WebApplication app)
        {
            //To Navigate
            //https://localhost:7131/health

            // Map health check endpoints
            app.MapHealthChecks("/health");
            app.MapHealthChecks("/health/random");

            //FindByTag
            app.MapHealthChecks("/health/tags/api", new HealthCheckOptions
            {
                Predicate = (check) => check.Tags.Contains("API")
            });
            //Find Details
            app.MapHealthChecks("/health/ui", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }

    }
}
