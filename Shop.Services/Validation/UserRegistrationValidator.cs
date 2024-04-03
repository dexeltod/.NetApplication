using FluentValidation;
using WebApplication2.Controllers.Products.Api;

namespace Shop.Services.Validation;

public class UserRegistrationValidator : AbstractValidator<UserData>
{
	public UserRegistrationValidator()
	{
		RuleFor(customer => customer.Login).NotNull();
		RuleFor(customer => customer.Password).NotNull().MinimumLength(5);
		RuleFor(customer => customer.Email).EmailAddress();
	}
}