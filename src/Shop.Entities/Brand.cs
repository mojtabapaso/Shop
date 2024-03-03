namespace Shop.Entities;

public class Brand : BaseEntitiy
{
	public string Name { get; set; }
	public ICollection<Product> Brands { get; set; } = new List<Product>();
}
