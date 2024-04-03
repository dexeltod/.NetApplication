using Shop.DomainInterfaces;
using Shop.ServicesInterfaces;

namespace Shop.Services.Repositoryes.Common;

public abstract class Repository<T>(WebApplicationContext context) : IRepository<T>
	where T : class, IRepositoryItem
{
	protected readonly WebApplicationContext Context = context ?? throw new ArgumentNullException(nameof(context));

	public abstract Task<List<T>> GetAll();

	public abstract Task Add(T target);

	public abstract Task<Guid> Remove(Guid id);
	public abstract Task<Guid> Edit(T target);
	public abstract Task<T> GetById(Guid id);
	public abstract Task<List<T>> GetByCount(int count);
}