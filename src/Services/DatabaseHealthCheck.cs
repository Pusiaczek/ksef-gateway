using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace KsefGateway.Services;

public class SampleHealthCheck : IHealthCheck
{
	public Task<HealthCheckResult> CheckHealthAsync(
			HealthCheckContext context, CancellationToken cancellationToken = default)
	{
		var isHealthy = true;

		// ...

		if (isHealthy)
		{

			Console.WriteLine("---------------- CZEKUJEMY HELFA!!!");
			return Task.FromResult(
					HealthCheckResult.Healthy("A healthy result."));
		}

		return Task.FromResult(
				new HealthCheckResult(
						context.Registration.FailureStatus, "An unhealthy result."));
	}
}