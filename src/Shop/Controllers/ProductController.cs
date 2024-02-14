using Microsoft.AspNetCore.Mvc;
using Shop.services.Contracts;

namespace Shop.Controllers;

public class ProductController : Controller
{
	private readonly IProductServisec productServisec;

	public ProductController(IProductServisec productServisec)
	{
		this.productServisec = productServisec;
	}
	public IActionResult Details(int id)
	{
		return View();
	}
	[HttpGet("/Search")]
	public async Task<IActionResult> Search(string quary)
	{
		var products = await productServisec.SearchAsync(quary);
		return View(products);
	}
}