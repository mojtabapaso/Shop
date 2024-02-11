using Microsoft.AspNetCore.Mvc;

namespace Shop.Areas.Admin.Controllers;

[Area(AreaConstants.AdminArea)]
public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
