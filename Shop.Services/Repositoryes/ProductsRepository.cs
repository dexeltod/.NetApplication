using ClassLibrary1.Domain;
using Microsoft.EntityFrameworkCore;
using Shop.DataBase;

namespace Shop.Services;

public class ProductsRepository : Repository<Product>, IProductsRepository
{
	private readonly ProductsContext _context;

	public ProductsRepository(ProductsContext context) =>
		_context = context ?? throw new ArgumentNullException(nameof(context));

	public override async Task Add(Product product)
	{
		if (product == null) throw new ArgumentNullException(nameof(product));

		await _context.Products.AddAsync(product);
		await _context.SaveChangesAsync();
	}

	public override async Task<Product> GetById(Guid id)
	{
		List<Product> products = await _context.Products.AsNoTracking().ToListAsync();

		Product? a = products.FirstOrDefault(x => x.Id == id);

		if (a != null)
			return a;

		throw new ArgumentNullException($"product with if {id} does not exist");
	}

	public override async Task<Guid> Remove(Guid id)
	{
		var product = _context.Products.Where(x => x.Id == id) ??
			throw new ArgumentNullException($"product with id {id} does not exist");

		await product.ExecuteDeleteAsync();

		await _context.SaveChangesAsync();

		return id;
	}

	public override async Task<List<Product>> GetAll()
	{
		List<Product> products = await _context.Products.AsNoTracking().ToListAsync();

		if (products != null)
			return products;

		throw new ArgumentNullException($"{products}");
	}

	public override async Task<Guid> Edit(Product product)
	{
		IQueryable<Product> foundProduct = _context.Products.Where(x => x.Id == product.Id) ??
			throw new ArgumentNullException($"product {product} does not exist");

		await foundProduct.ExecuteUpdateAsync(
			s => s.SetProperty(v => v.Name, product.Name)
				.SetProperty(v => v.Price, product.Price)
				.SetProperty(v => v.Description, product.Description)
		);

		return product.Id;
	}
}