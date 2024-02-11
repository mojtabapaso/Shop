using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.Contracts;

namespace Shop.Services.EFServices;

public class  ProductServisec : GenericServices<Product>, IProductServisec
{
	private readonly IUnitOfWork ـuow;
	private readonly DbSet<Product> _product;
	public ProductServisec(IUnitOfWork uow):base(uow)
	{
		ـuow = uow;
		_product = uow.Set<Product>();
	}
}


