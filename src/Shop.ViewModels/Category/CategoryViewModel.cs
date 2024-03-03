using Shop.Entities;

namespace Shop.ViewModels.Category;

public class CategoryViewModel:BaseViewModel
{
	public string Name { get; set; }
	public bool IsSubCategory { get; set; }
	public virtual ICollection<Product> Products { get; set; }

	public virtual ICollection<Shop.Entities.Category> SubCategories { get; set; }

}
