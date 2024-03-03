using System.ComponentModel.DataAnnotations;

namespace Shop.Entities;
public enum ProductStatus
{
	ActivePublished,
	OutOfStock,
	Inactive,

}

public class Product : BaseEntitiy
{
	[MaxLength(100)]
	[Required]
	public string Title { get; set; }
	[MaxLength(1000)]
	public string Description { get; set; }
	public int Price { get; set; }
	public string ImagePath { get; set; }
	public int Quantity { get; set; }
	public ProductStatus Status { get; set; }
	public string Color { get; set; } = string.Empty;
	public string Model { get; set; } = string.Empty;
	public decimal Weight { get; set; }
	public string Manufacturer { get; set; }
	public virtual Brand? Brand { get; set; }
	public virtual ICollection<Tag> Tags { get; set; }= new List<Tag>();
	public virtual Category? Category { get; set; }  
	public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

}
