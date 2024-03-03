using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels.Account;

public class ChangePasswordViewModel
{
	[Required(ErrorMessage = "رمز عبور را وارد کنید")]
	public string OldPassword { get; set; }
	[Required(ErrorMessage = "رمز عبور جدید را وارد کنید")]
	[StringLength(100, ErrorMessage = "حداقل طول رمز عبور باید 8 کاراکتر باشد")]
	[DataType(DataType.Password)]
	public string NewPassword { get; set; }
	[Compare("NewPassword", ErrorMessage = "رمز عبور جدید و تأیید آن مطابقت ندارند")]
	[DataType(DataType.Password)]
	public string ConfirmNewPassword { get; set; }
}
