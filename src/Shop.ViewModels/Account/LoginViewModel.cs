using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels.Account;

public class LoginViewModel
{
	[Required(ErrorMessageResourceName = "Error Message", ErrorMessage = "Error Message")]
	public string? PhoneNumber { get; set; }
}
