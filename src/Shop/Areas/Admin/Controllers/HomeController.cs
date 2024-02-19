using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Areas.Admin.Controllers;

//[Authorize(Roles = "Admin")]
[Area(AreaConstants.AdminArea)]

public class HomeController : Controller
{
	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}
	public IActionResult ChangeLanguage(string name, string returnUrl)
	{
		Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(name)),
				new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
				);
		return LocalRedirect(returnUrl);
	}

}
