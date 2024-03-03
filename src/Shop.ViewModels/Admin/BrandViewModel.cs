using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels.Admin;

public class BrandViewModel
{
    public string? Id { get; set; }
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Please enter {0} ")]
    public string Name { get; set; }
}
