using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace Shop.DataBase.Configuration;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
	public void Configure(EntityTypeBuilder<News> builder) =>
		throw new NotImplementedException();
}