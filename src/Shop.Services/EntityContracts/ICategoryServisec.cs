using Shop.Entities;
using Shop.services.Contracts;

namespace Shop.Services.EntityContracts;

public interface ICategoryServisec : IGenericServices<Category>
{
    public Task<ICollection<Category>> GetMainCategories();
    public Task<ICollection<Category>> GetSubCategories(Category category);
    public Task<ICollection<Category>> GetSubCategories(string id);

}
