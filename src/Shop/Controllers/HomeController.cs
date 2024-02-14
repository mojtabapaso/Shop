using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Shop.Models;
using Shop.services.Contracts;
using Shop.ViewModels.Products;
using Microsoft.AspNetCore.Http.Features;
namespace Shop.Controllers;
public class HomeController : Controller
{

	private readonly ILogger<HomeController> logger;
	private readonly IStringLocalizer<HomeController> localizer;
	private readonly IProductServisec productServisec;
	//private readonly IUnitOfWork uow;
	private readonly IConfiguration configuration;
	private readonly IWebHostEnvironment env;
	private readonly IMemoryCache memoryCache;

	public HomeController(ILogger<HomeController> logger,
		IStringLocalizer<HomeController> localizer,
		IProductServisec productServisec,
		//IUnitOfWork uow,
		IConfiguration configuration,
		IWebHostEnvironment env,
		IMemoryCache memoryCache)
	{
		this.logger = logger;
		this.localizer = localizer;
		this.productServisec = productServisec;
		//this.uow = uow;
		this.configuration = configuration;
		this.env = env;
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

	[HttpPost]
	public async Task<IActionResult> AddProductAsync(AddProductViewModel model)
	{

		if (!ModelState.IsValid)
		{
			ModelState.AddModelError(string.Empty, "Please enter valid input.");
			return View(model);
		}
		//_productServisec.Add()
		//_productServisec.Add(
		//    new Product()
		//    {
		//        Title = model.Title,
		//        Description = model.Description,
		//    });
		//await _uow.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[Authorize]
	public IActionResult Privacy()
	{
		return View();
	}


	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}

}


