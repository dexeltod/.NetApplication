﻿using Shop.DomainInterfaces;

namespace Shop.Domain;

public class ProductsModel(List<IProduct> products) : IProducts
{
	private readonly List<IProduct> _products = products ?? throw new ArgumentNullException(nameof(products));

	public void Add(IProduct product)
	{
		if (product == null) throw new ArgumentNullException(nameof(product));

		_products.Add(product);
	}

	public IReadOnlyList<IProduct> Products => _products;

	public void Remove(Guid id)
	{
		IProduct? product = _products.FirstOrDefault(elem => elem.Id == id);

		_products.Remove(product ?? throw new InvalidOperationException($"Product with id {id} not found"));
	}
}