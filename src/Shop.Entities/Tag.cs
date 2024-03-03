using System.ComponentModel.DataAnnotations;

namespace Shop.Entities;

public class Tag : BaseEntitiy
{

	[Required]
	[MaxLength(100)]
	public string Name { get; set; }
	public virtual ICollection<Product> Products { get; set; } = new List<Product>();

}
