namespace Shop.DomainInterfaces;

public interface IPost : IRepositoryItem
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public Guid AuthorId { get; set; }

	public IUser Author { get; set; }
}