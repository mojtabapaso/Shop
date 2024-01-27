using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.Contracts;

namespace Shop.Services.EFServices;

public class  ProductServisec : IProductServisec
{
	private readonly IUnitOfWork ـuow;
	private readonly DbSet<Product> _product;
	public ProductServisec(IUnitOfWork uow)
	{
		ـuow = uow;
		_product = uow.Set<Product>();
	}
	public void Add(Product product)
	{
		_product.Add(product);
	}
	public List<Product> GetAll()
	{
		return _product.ToList();
	}
}


