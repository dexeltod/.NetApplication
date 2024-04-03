namespace Shop.ServicesInterfaces;

public interface IRepository<T> where T : class
{
	Task<List<T>> GetAll();
	Task<List<T>> GetByCount(int count);
	Task Add(T target);
	Task<T> GetById(Guid id);
	Task<Guid> Remove(Guid id);
	Task<Guid> Edit(T product);
}