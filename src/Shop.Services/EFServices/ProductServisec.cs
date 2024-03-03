using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;

namespace Shop.Services.EFServices;

public class ProductServisec : GenericServices<Product>, IProductServisec
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<Product> product;
    public ProductServisec(IUnitOfWork uow) : base(uow)
    {
        this.uow = uow;
        product = uow.Set<Product>();
    }

    public async Task<List<Product>?> SearchAsync(string query)
    {
        if (query == null)
        {
            return null;
        }
        query = query.ToLowerInvariant();

        var products = await product.Where(p => p.Title.ToLower().Contains(query))
        .Where(p => p.Description.ToLower().Contains(query)).ToListAsync();
        //.Where(p => p.Brand.ToLower().Contains(query))
        return products;
    }
    public async Task<List<Product>> GetAllWithModelCommentsAsync()
    {
        return await product.Include(product => product.Comments).ToListAsync();
    }
    public async Task<List<Product>> GetAllWithModelTagsAsync()
    {
        return await product.Include(product => product.Tags).ToListAsync();
    }
    public async Task<List<Product>> GetAllWithModelCategoryAsync()
    {
        return await product.Include(product => product.Category).ToListAsync();
    }
    public async Task<List<Product>> GetAllWithAllRelatedModelsAsync()
    {
        return await product.Include(product => product.Tags)
            .Include(product => product.Category)
            .Include(product => product.Comments).ToListAsync();
    }
    public async Task<Product?> FindByIdWithModelCommentsAsync(string id)
    {
        return await product.Include(c => c.Comments).FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<Product?> FindByIdWithModelTagsAsync(string id)
    {
        return await product.Include(t => t.Tags).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product?> FindByIdWithModelCategoryAsync(string id)
    {
        return await product.Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id);

    }

    public async Task<Product?> FindByIdWithAllRelatedModelsAsync(string id)
    {
        return await product.Include(c => c.Comments).Include(t => t.Tags).Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id);
    }
}



