using System.ComponentModel.DataAnnotations;
using Shop.Entities;

namespace Shop.ViewModels;

public class AddressViewModel
{
	public string Title { get; set; }
	public string Text { get; set; }
	[MinLength(1)]
	[Required]
	public string PostalCode { get; set; }
	[MinLength(1)]
	[Required]
	public string HouseNumber { get; set; }
}
