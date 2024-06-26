namespace Shop.DomainInterfaces;

public interface IProducts
{
	IReadOnlyList<IProduct> Products { get; }
	void Add(IProduct product);
	void Remove(Guid id);
}