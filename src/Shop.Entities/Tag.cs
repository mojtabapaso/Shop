using System.ComponentModel.DataAnnotations;

namespace Shop.Entities;

public class Tag
{
	public int Id { get; set; }

	[Required]
	[MaxLength(100)]
	public string Name { get; set; }

}