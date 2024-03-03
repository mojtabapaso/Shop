using Shop.Common.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Shop.ViewModels.Admin;

namespace Shop.ViewModels.Products;
public class ProductCreateAdminViewModel
{
    [Required]
	public TagViewModel TagViewModel { get; set; }
    [Required]
	public ProductViewModel ProductViewModel { get; set; }
}

//public class ProductViewModel
//{
//    [DisplayName("Title")]
//    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
//    public string Title { get; set; }

//    [DisplayName("Description")]
//    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
//    public string Description { get; set; }

//    [DisplayName("Price")]
//    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
//    public int Price { get; set; }

//    [DisplayName("Quantity")]
//    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
//    public int Quantity { get; set; }
//    public string? Color { get; set; }
//    public string? Model { get; set; }
//    public decimal Weight { get; set; }
//    public string Manufacturer { get; set; }
//    public string Brand { get; set; }
//    //public ICollection<TagViewModel> Tags { get; set; }
//}

