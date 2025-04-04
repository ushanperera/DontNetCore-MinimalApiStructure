using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DontNetCore_MinimalApiStructure.HealthChecks
{
    public class RandomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int randomNumber = new Random().Next(1, 4);

            return randomNumber switch
            {
                1 => Task.FromResult(HealthCheckResult.Healthy("API is healthy")),
                2 => Task.FromResult(HealthCheckResult.Unhealthy("API is unhealthy")),
                3 => Task.FromResult(HealthCheckResult.Degraded("API is degraded")),
                _ => Task.FromResult(HealthCheckResult.Unhealthy("API is unhealthy"))
            };

        }

    }
}
