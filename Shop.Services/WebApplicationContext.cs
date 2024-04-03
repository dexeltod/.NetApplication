using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace Shop.Services;

public partial class WebApplicationContext : DbContext
{
	public WebApplicationContext() { }

	public WebApplicationContext(DbContextOptions<WebApplicationContext> options)
		: base(options) { }

	public virtual DbSet<News> News { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<User> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<News>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__News__3214EC07B53ED6BD");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Title).HasMaxLength(50);

			entity.HasOne(d => d.Author).WithMany(p => p.News)
				.HasForeignKey(d => d.AuthorId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_News_User");
		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.ToTable("User");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.About).HasColumnType("text");
			entity.Property(e => e.Email)
				.HasMaxLength(320)
				.IsUnicode(true);
			entity.Property(e => e.Login).HasMaxLength(50);
			entity.Property(e => e.Name).HasMaxLength(50);
			entity.Property(e => e.Nickname).HasMaxLength(50);
			entity.Property(e => e.Surname).HasMaxLength(50);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}