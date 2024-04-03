namespace WebApplication2.Controllers.Products.Api;

public class UserData
{
	public string Login { get; private set; }
	public string Password { get; private set; }
	public string Email { get; private set; }

	public UserData(string login, string password, string email)
	{
		Login = login;
		Password = password;
		Email = email;
	}
}