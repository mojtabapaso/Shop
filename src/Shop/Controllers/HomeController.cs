using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Shop.Models;
using Shop.ViewModels.Products;
using Microsoft.AspNetCore.Localization;
using Shop.DataLayer.context;
using Shop.Services.EntityContracts;

namespace Shop.Controllers;
public class HomeController : Controller
{

	private readonly ILogger<HomeController> logger;
	private readonly IStringLocalizer<HomeController> localizer;
	private readonly IProductServisec productServisec;
	private readonly IStringLocalizer<HomeController> stringLocalizer;
	private readonly IUnitOfWork uow;
    private readonly IConfiguration configuration;
	private readonly IWebHostEnvironment env;
	private readonly IHttpContextAccessor httpContextAccessor;
	private readonly IMemoryCache memoryCache;

	public HomeController(ILogger<HomeController> logger,
		IStringLocalizer<HomeController> localizer,
		IProductServisec productServisec,
		IUnitOfWork uow,
        IStringLocalizer<HomeController> stringLocalizer,
		IConfiguration configuration,
		IWebHostEnvironment env,
		IHttpContextAccessor httpContextAccessor,
		IMemoryCache memoryCache)
	{
		this.logger = logger;
		this.localizer = localizer;
		this.productServisec = productServisec;
		this.stringLocalizer = stringLocalizer;
		this.uow = uow;
        this.configuration = configuration;
		this.env = env;
		this.httpContextAccessor = httpContextAccessor;
		this.memoryCache = memoryCache;
	}

	public IActionResult Index()
	{
        return View();
	}
	[ResponseCache(Duration = 60)]
	public IActionResult AddProduct()
	{
		return View();
	}
	public IActionResult Add()
	{
		return View();
	}

	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> AddProductAsync(AddProductViewModel model)
	{
		if (!ModelState.IsValid)
		{
			ModelState.AddModelError(string.Empty, stringLocalizer["Please enter valid input"]);
			return View(model);
		}
		return RedirectToAction(nameof(Index));
	}
	[HttpPost, ValidateAntiForgeryToken]
	public IActionResult ChangeLanguage(string name, string returnUrl)
	{
		Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(name)),
				new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
				);
		return LocalRedirect(returnUrl);
	}
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}

}


