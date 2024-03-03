using Shop.Entities;
using Shop.services.Contracts;

namespace Shop.Services.EntityContracts;

public interface IProductServisec : IGenericServices<Product>
{
    public Task<List<Product>?> SearchAsync(string query);
    public Task<List<Product>> GetAllWithModelCommentsAsync();
    public Task<List<Product>> GetAllWithModelTagsAsync();
    public Task<List<Product>> GetAllWithModelCategoryAsync();
    public Task<List<Product>> GetAllWithAllRelatedModelsAsync();
    public Task<Product> FindByIdWithModelCommentsAsync(string id);
    public Task<Product> FindByIdWithModelTagsAsync(string id);
    public Task<Product> FindByIdWithModelCategoryAsync(string id);
    public Task<Product> FindByIdWithAllRelatedModelsAsync(string id);
}
