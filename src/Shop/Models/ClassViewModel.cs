using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shop.Model;

public class ClassViewModel2
{

	[Required(ErrorMessage = "Error")]
	[Display(Name = "Phone Number")]
	public string? PhoneNumber { get; set; }
}
