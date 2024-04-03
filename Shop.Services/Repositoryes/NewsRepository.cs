using Microsoft.EntityFrameworkCore;
using Shop.Services.Repositoryes.Common;
using WebApplication2.Models;

namespace Shop.Services.Repositoryes;

public class NewsRepository(WebApplicationContext context) : Repository<News>(context)
{
	private readonly WebApplicationContext _context = context ?? throw new ArgumentNullException(nameof(context));

	public override async Task Add(News target)
	{
		ArgumentNullException.ThrowIfNull(target);

		await _context.News.AddAsync(target);
		await _context.SaveChangesAsync();
	}

	public override Task<Guid> Remove(Guid id) =>
		throw new NotImplementedException();

	public override Task<Guid> Edit(News product) =>
		throw new NotImplementedException();

	public override Task<News> GetById(Guid id)
	{
		IQueryable<News> a = _context.News.FromSql($"SELECT * FROM dbo.News");

		return null!;
	}

	public override async Task<List<News>> GetAll()
	{
		var result = await _context.News.AsNoTracking().ToListAsync();
		if (result == null) throw new ArgumentNullException(nameof(result));
		return result;
	}

	public override async Task<List<News>> GetByCount(int count) =>
		await _context.News.AsNoTracking().Take(count).ToListAsync();
}