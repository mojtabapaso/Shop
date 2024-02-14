using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Areas.Admin.Controllers;

[Area(AreaConstants.AdminArea)]

public class HomeController : Controller
{
	[HttpGet]
	[Authorize(Roles = "Admin")]
	public IActionResult Index()
	{
		return View();
	}
}
