using System.ComponentModel.DataAnnotations;

namespace Shop.Entities;
public enum ProductStatus
{
	OutOfStock,
	Inactive,
	ActivePublished
}

public class Product : BaseEntitiy
{
	[MaxLength(100)]
	[Required]
	public string Title { get; set; }
    public string Slug { get; set; }
    public Product()
    {
        Slug = Title.Substring(0, 10);
    }
    [MaxLength(1000)]
	public string Description { get; set; }
	public int Price { get; set; }
	public int Quantity { get; set; }
	public ProductStatus Status { get; set; }
	public virtual ICollection<Tag>? Tags { get; set; }
	public string? Color { get; set; } = string.Empty;
	public string? Model { get; set; } = string.Empty;
	public decimal	Weight { get; set; } 
	public string Manufacturer { get; set; }
	public string Brand { get; set; }

}
