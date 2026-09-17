using Microsoft.EntityFrameworkCore;

namespace KsefGateway.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<KsefContext> KsefContexts { get; set; }
}