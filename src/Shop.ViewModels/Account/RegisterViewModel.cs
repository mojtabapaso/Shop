using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Shop.Common.Constants;
// ^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$

namespace Shop.ViewModels.Account;

public class RegisterViewModel
{
	[DisplayName("Phone Number")]
	[Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
	[StringLength(maximumLength: 11, ErrorMessage = AttributesErrorMessages.StringLenghtMessage, MinimumLength = 11)]
	[Remote("RegexValidatePhoneNumber", "Account", ErrorMessage = AttributesErrorMessages.RemoteMessageReGexPhoneNumber, HttpMethod = "POST")]
	public string? PhoneNumber { get; set; }
}
