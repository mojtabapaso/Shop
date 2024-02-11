using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shop.Common.Constants;

namespace Shop.ViewModels.Account;

public class CodeOTPViewModel
{
	[DisplayName("کد ارسالی")]
	[Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
	[MinLength(6,ErrorMessage = AttributesErrorMessages.MinLenghtMessage)]
	public string? Code { get; set;}

	[DisplayName("شماره تلفن")]
	public string? PhoneNumber { get; set; }
}
