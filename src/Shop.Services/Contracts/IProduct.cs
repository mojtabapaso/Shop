using Shop.Entities;

namespace Shop.services.Contracts;

public interface IProductServisec : IGenericServices<Product>
{
	public Task<List<Product>?> SearchAsync(string query);
}
