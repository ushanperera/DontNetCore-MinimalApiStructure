using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DontNetCore_MinimalApiStructure.HealthChecks
{
    public class ApiHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // Perform your health check logic here
            // For example, check if a database connection is healthy
            return Task.FromResult(HealthCheckResult.Healthy("API is healthy"));
        }

    }
}