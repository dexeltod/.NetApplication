using Shop.Services;

namespace ClassLibrary1.Domain;

public class Product : IRepositoryItem, IProduct
{
	public Product(Guid id, string name, decimal price, string? description)
	{
		if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
		Id = id;
		Name = name ?? throw new ArgumentNullException(nameof(name));
		Price = price;
		Description = description ?? throw new ArgumentNullException(nameof(description));
	}

	public Guid Id { get; private set; }
	public string Name { get; private set; }
	public decimal Price { get; private set; }
	public string? Description { get; private set; }
}