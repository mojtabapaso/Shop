using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;

namespace Shop.Services.EFServices;

public class CategoryServices : GenericServices<Category>, ICategoryServisec
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<Category> category;
    public CategoryServices(IUnitOfWork uow) : base(uow)
    {
        this.uow = uow;
        category = uow.Set<Category>();
    }
    public async Task<ICollection<Category>> GetMainCategories()
    {
        var categories = await category.Where(c => c.IsSubCategory == false).ToListAsync();
        return categories;
    }

    public async Task<ICollection<Category>> GetSubCategories(Category categoryModel)
    {
        var subcategories = categoryModel.SubCategories;
        return subcategories;
    }
    public async Task<ICollection<Category>> GetSubCategories(string id)
    {
        var categories = await category.Where(c => c.Id == id && c.IsSubCategory == false).ToListAsync();
        var subcategories = new List<Category>();
        foreach (var item in categories)
        {
            if (item.IsSubCategory)
            {
                subcategories.AddRange(item.SubCategories);
            }
        };
        return subcategories;
    }
}
