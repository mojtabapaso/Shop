using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;

namespace Shop.Areas.Admin.Controllers;

[Area(AreaConstants.AdminArea)]
[Authorize(Roles = "Admin")]
public class AccountController : Controller
{
	private readonly SignInManager<User> signInManager;

	public AccountController(SignInManager<User> signInManager)
	{
		this.signInManager = signInManager;
	}
	public IActionResult Index()
	{
		return View();
	}
	public async Task<IActionResult> Logout()
	{
		await signInManager.SignOutAsync();
		return RedirectToRoute("~/");
	}

}
