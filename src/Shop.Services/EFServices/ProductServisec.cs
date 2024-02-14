using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.services.Contracts;

namespace Shop.services.EFServices;

public class ProductServisec : GenericServices<Product>, IProductServisec
{
	private readonly IUnitOfWork ـuow;
	private readonly DbSet<Product> _product;
	public ProductServisec(IUnitOfWork uow) : base(uow)
	{
		ـuow = uow;
		_product = uow.Set<Product>();
	}

	public async Task<List<Product>?> SearchAsync(string query)
	{
		if (string.IsNullOrEmpty(query))
		{
			return null;
		}
		query = query.ToLowerInvariant();

		var products = await _product.Where(p => p.Title.ToLower().Contains(query))
		.Where(p => p.Description.ToLower().Contains(query))
		.Where(p => p.Brand.ToLower().Contains(query)).ToListAsync();

		return products;
	}
}


