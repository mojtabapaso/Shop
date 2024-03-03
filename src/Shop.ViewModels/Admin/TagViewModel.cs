using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Entities;

namespace Shop.ViewModels.Admin;


public class TagViewModel : BaseViewModel
{
	[Required]
	public string Name { get; set; }
	public ICollection<Product>? Products { get; set; }
    public string[]? ProductId { get; set; }
    public List<SelectListItem>? selectListItemProducts { get; set; }
}

