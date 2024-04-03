using Shop.DomainInterfaces;

namespace WebApplication2.Models;

public partial class News : IRepositoryItem
{
	public Guid Id { get; set; }
	public string Title { get; set; } = null!;
	public string Description { get; set; } = null!;
	public Guid AuthorId { get; set; }
	public virtual User Author { get; set; } = null!;
}