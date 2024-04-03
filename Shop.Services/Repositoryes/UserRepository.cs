using Microsoft.EntityFrameworkCore;
using Shop.Services.Repositoryes.Common;
using WebApplication2.Models;

namespace Shop.Services.Repositoryes;

public sealed class UserRepository(WebApplicationContext context) : Repository<User>(context)
{
	private readonly WebApplicationContext _context = context;

	public override async Task Add(User target)
	{
		ArgumentNullException.ThrowIfNull(target);
		await _context.Users.AddAsync(target);
	}

	public override Task<Guid> Remove(Guid id) =>
		throw new NotImplementedException();

	public override Task<Guid> Edit(User target) =>
		throw new NotImplementedException();

	public override async Task<User> GetById(Guid id)
	{
		User? result = await _context.Users.AsNoTracking().FirstAsync<User>(element => element.Id == id);
		if (result == null) throw new ArgumentNullException(nameof(result));
		return result;
	}

	public override Task<List<User>> GetAll() =>
		throw new NotImplementedException();

	public override Task<List<User>> GetByCount(int count) =>
		throw new NotImplementedException();
}