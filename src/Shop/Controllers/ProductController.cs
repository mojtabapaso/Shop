using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

public class ProductController : Controller
{
	public ActionResult Details(int id)
	{
		return View();
	}
}