using ClassLibrary1.Domain;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain;

namespace WebApplication2.Controllers.Products;

public class ProductsController : Controller
{
	private readonly ProductsApiController _productsApiController;

	public ProductsController(ProductsApiController productsApiController)
	{
		_productsApiController = productsApiController ?? throw new ArgumentNullException(nameof(productsApiController));
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		List<Product> products = await _productsApiController.GetAll();

		ProductsModel model = new ProductsModel(new List<IProduct>(products));
		return View(model);
	}
}