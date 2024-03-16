using ClassLibrary1.Domain;
using Microsoft.EntityFrameworkCore;

namespace Shop.DataBase;

public sealed class ProductsContext : DbContext
{
	public DbSet<Product> Products { get; set; } = null!;

	public ProductsContext(DbContextOptions options) : base(options) =>
		Database.EnsureCreated();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>();

		base.OnModelCreating(modelBuilder);
	}
}