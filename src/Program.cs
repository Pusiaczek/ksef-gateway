using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using KsefGateway.Data;
using KsefGateway.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<KsefOptions>()
	.Bind(builder.Configuration.GetSection("Ksef"))
	.ValidateDataAnnotations()
	.ValidateOnStart();

builder.Services.AddHealthChecks().AddDbContextCheck<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
		options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapHealthChecks("/healthz");


Console.WriteLine("---- START ---- \n");
Console.WriteLine(builder.Configuration.GetConnectionString("Default"));
Console.WriteLine("\n---- STOP ----");


using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	var canConnect = await db.Database.CanConnectAsync();
	Console.WriteLine($"Can connect to database: {canConnect}");
}

app.Run();

