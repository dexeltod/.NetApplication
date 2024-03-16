using ClassLibrary1.Domain;
using Microsoft.AspNetCore.Mvc;
using Shop.Services;

namespace WebApplication2.Controllers;

[ApiController] [Route("api/products")]
public class ProductsApiController : ControllerBase
{
	private readonly IProductsRepository _productsRepository;

	public ProductsApiController(IProductsRepository productsRepository) =>
		_productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));

	[HttpGet]
	public async Task<List<Product>> GetAll()
	{
		var products = await _productsRepository.GetAll();
		Ok();
		return products;
	}

	[HttpPost]
	public async Task PostOneProduct() =>
		await _productsRepository.Add(new Product(Guid.NewGuid(), "test", 3, "das"));
}