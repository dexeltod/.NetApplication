namespace ClassLibrary1.Domain;

public interface IProduct
{
	Guid Id { get; }
	string Name { get; }
	decimal Price { get; }
	string? Description { get; }
}