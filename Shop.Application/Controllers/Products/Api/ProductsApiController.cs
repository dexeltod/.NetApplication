using Microsoft.AspNetCore.Mvc;
using Shop.ServicesInterfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Products.Api;

[ApiController] [Route("api/products")]
public class ProductsApiController(IProductsRepository productsRepository) : ControllerBase
{
	private readonly IProductsRepository _productsRepository
		= productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));

	[HttpGet]
	public async Task<List<Product>> GetAll()
	{
		List<Product> products = await _productsRepository.GetAll();
		Ok();
		return products;
	}

	[HttpPost]
	public async Task Add(Product product) =>
		await _productsRepository.Add(product);
}