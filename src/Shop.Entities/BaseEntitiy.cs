using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.Entities;

public class BaseEntitiy
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	//public Guid Id { get; set; }
	public string Id { get; set; }
}
