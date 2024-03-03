using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Entities;

namespace Shop.ViewModels.Admin;

public class ProductViewModel
{
    public string? Id { get; set; }
    [DisplayName("عنوان")]
    public string Title { get; set; }

    [DisplayName("توضیحات")]

    public string Description { get; set; }
    [DisplayName("قیمت")]

    public int Price { get; set; }
    [DisplayName("تعداد")]

    public int Quantity { get; set; }
    [DisplayName("وضعیت")]
	[Required(ErrorMessage = "Please select files")]
	public IFormFile ImageFile { get; set; }
	public ProductStatus Status { get; set; }

	public string[]? Tag { get; set; }
	[DisplayName("تگ ها ")]
    public List<SelectListItem>? Tags { get; set; }

    [DisplayName("رنگ")]

    public string Color { get; set; }
    [DisplayName("مدل")]

    public string Model { get; set; }
    [DisplayName("وزن")]

    public decimal Weight { get; set; }
    [DisplayName("نام سازنده")]

    public string Manufacturer { get; set; }
    [DisplayName("نام تجاری")]
    public string Brand { get; set; }

}

