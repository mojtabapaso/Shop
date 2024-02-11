using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shop.Models;
using Shop.Services.Contracts;
using Shop.ViewModels.Products;

namespace Shop.Controllers;
public class HomeController : Controller
{

	private readonly ILogger<HomeController> _logger;
	private readonly IProductServisec _productServisec;
	//private readonly IUnitOfWork uow;
	private readonly IConfiguration configuration;
	private readonly IWebHostEnvironment env;
	private readonly IMemoryCache memoryCache;

	public HomeController(ILogger<HomeController> logger,
		IProductServisec productServisec,
		//IUnitOfWork uow,
		IConfiguration configuration,
		IWebHostEnvironment env,
		IMemoryCache memoryCache)
	{
		_logger = logger;
		_productServisec = productServisec;
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


