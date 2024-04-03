using Microsoft.EntityFrameworkCore;
using Shop.Services.Repositoryes.Common;
using Shop.ServicesInterfaces;
using WebApplication2.Models;

namespace Shop.Services.Repositoryes;

public class ProductsRepository(WebApplicationContext context) : Repository<Product>(context), IProductsRepository
{
	public override async Task Add(Product target)
	{
		ArgumentNullException.ThrowIfNull(target);

		await Context.Products.AddAsync(target);
		await Context.SaveChangesAsync();
	}

	public override async Task<Product> GetById(Guid id)
	{
		List<Product> products = await Context.Products.AsNoTracking().ToListAsync();

		Product? product = products.FirstOrDefault(x => x.Id == id);

		if (product != null)
			return product;

		throw new ArgumentNullException($"@target with if {id} does not exist");
	}

	public override async Task<Guid> Remove(Guid id)
	{
		var product = Context.Products.Where(x => x.Id == id) ??
			throw new ArgumentNullException($"@target with id {id} does not exist");

		await product.ExecuteDeleteAsync();

		await Context.SaveChangesAsync();

		return id;
	}

	public override async Task<List<Product>> GetAll()
	{
		List<Product> products = await Context.Products.AsNoTracking().ToListAsync();

		if (products == null)
			throw new ArgumentNullException($"{products}");

		return products;
	}

	public override Task<List<Product>> GetByCount(int count) =>
		throw new NotImplementedException();

	public override async Task<Guid> Edit(Product product)
	{
		IQueryable<Product> foundProduct = Context.Products.Where(x => x.Id == product.Id) ??
			throw new ArgumentNullException($"@target {product} does not exist");

		await foundProduct.ExecuteUpdateAsync(
			s => s.SetProperty(v => v.Name, product.Name)
				.SetProperty(v => v.Price, product.Price)
				.SetProperty(v => v.Description, product.Description)
		);

		return product.Id;
	}
}