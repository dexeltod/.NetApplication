using ClassLibrary1.Domain;

namespace Shop.Services;

public abstract class Repository<T> : IRepository<T> where T : class, IRepositoryItem
{
	public abstract Task Add(T product);
	public abstract Task<Guid> Remove(Guid id);
	public abstract Task<Guid> Edit(T product);
	public abstract Task<T> GetById(Guid id);
	public abstract Task<List<T>> GetAll();
}