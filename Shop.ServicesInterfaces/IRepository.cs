namespace Shop.Services;

public interface IRepository <T> where T : class, IRepositoryItem
{
	Task Add(T product);
	Task<Guid> Remove(Guid id);
	Task<Guid> Edit(T product);
	Task<T> GetById(Guid id);
	Task<List<T>> GetAll();
}