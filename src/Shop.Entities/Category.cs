namespace Shop.Entities;

public class Category : BaseEntitiy
{
    public string Name { get; set; }
    public bool IsSubCategory { get; set; } = false;
    public virtual ICollection<Category> SubCategories { get; set; } =  new List<Category>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}