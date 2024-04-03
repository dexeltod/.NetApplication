using Shop.DomainInterfaces;

namespace WebApplication2.Models;

public partial class Product : IRepositoryItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }
}
