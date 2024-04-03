using FluentValidation.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.Repositoryes;
using Shop.Services.Validation;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Products.Api;

[ApiController] [Route("api/users")] public class UsersApiController : ControllerBase
{
	private readonly UserRegistrationValidator _validator;

	public UsersApiController(UserRepository repository) =>
		_validator = new UserRegistrationValidator();

	[HttpPost("register")]
	public async Task<ValidationResult?> Register(UserData data)
	{
		Console.WriteLine("Register" + data.Email);
		ValidationResult? result = await _validator.ValidateAsync(data);
		if (result != null) return result;
		Ok();
		return result;
		// User user = new User()
		// {
		// 	Id = Guid.NewGuid(),
		// 	//убрать name
		// 	Surname = "null",
		// 	Nickname = login,
		// 	Login = login,
		// 	Password = password,
		// 	Avatar = null,
		// 	About = null,
		// 	Email = email,
		// 	News = null
		// };
		// await repository.Add(user);
	}
}