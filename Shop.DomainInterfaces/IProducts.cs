using ClassLibrary1.Domain;

namespace Shop.Domain;

public interface IProducts
{
	IReadOnlyList<IProduct> Products { get; }
	void Add(IProduct product);
	void Remove(Guid id);
}