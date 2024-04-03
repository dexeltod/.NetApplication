using Shop.DomainInterfaces;

namespace WebApplication2.Models;

public partial class User : IRepositoryItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? About { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<News>? News { get; set; } = new List<News>();
}
