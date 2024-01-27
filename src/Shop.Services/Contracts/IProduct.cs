using Shop.Entities;

namespace Shop.Services.Contracts;

public interface IProductServisec
{
	void Add(Product product);

	List<Product> GetAll();
}
