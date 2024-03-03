using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels;

public class BaseViewModel
{
    [Display(Name = "Id")]
    public string? Id { get; set; }
}