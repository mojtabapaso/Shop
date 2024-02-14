using System.ComponentModel;
using Shop.Entities;

namespace Shop.ViewModels.Admin.Porduct;

public class ProductViewModel
{

    public string Id { get; set; }
    [DisplayName("عنوان")]
    public string Title { get; set; }
    [DisplayName("اسلاگ")]

    public string Slug { get; set; }
    [DisplayName("توضیحات")]

    public string Description { get; set; }
    [DisplayName("قیمت")]

    public int Price { get; set; }
    [DisplayName("تعداد")]

    public int Quantity { get; set; }
    [DisplayName("وضعیت")]

    public ProductStatus Status { get; set; }
    [DisplayName("تگ ها ")]

    public List<string>? Tags { get; set; }
    [DisplayName("رنگ")]

    public string? Color { get; set; }
    [DisplayName("مدل")]

    public string? Model { get; set; }
    [DisplayName("وزن")]

    public decimal Weight { get; set; }
    [DisplayName("نام سازنده")]

    public string Manufacturer { get; set; }
    [DisplayName("نام تجاری")]
    public string Brand { get; set; }

    public ProductViewModel(Product product)
    {
        Id = product.Id;
        Title = product.Title;
        Slug = product.Slug;
        Description = product.Description;
        Price = product.Price;
        Quantity = product.Quantity;
        Status = product.Status;
        Tags = product.Tags?.Select(t => t.Name).ToList();
        Color = product.Color;
        Model = product.Model;
        Weight = product.Weight;
        Manufacturer = product.Manufacturer;
        Brand = product.Brand;
    }
}

