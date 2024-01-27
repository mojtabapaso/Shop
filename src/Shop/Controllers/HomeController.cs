using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Models;
using Shop.Services.Contracts;
using Shop.ViewModels.Products;

namespace Shop.Controllers;
public class HomeController : Controller
{
	
	private readonly ILogger<HomeController> _logger;
	private readonly IProductServisec _productServisec;
	private readonly ShopDbContext _dbContext;
	private readonly IUnitOfWork _uow;
    private readonly IConfiguration configuration;
    private readonly IWebHostEnvironment env;

    public HomeController(ILogger<HomeController> logger,IProductServisec productServisec,ShopDbContext dbContext,IUnitOfWork uow,IConfiguration configuration, IWebHostEnvironment env)
		
		
		
	{
		_logger = logger;
		_productServisec = productServisec;
		_dbContext = dbContext;
		_uow = uow;
        this.configuration = configuration;
        this.env = env;
    }

	public IActionResult Index()
	{
		if (env.IsDevelopment())
			return Content("Welcom Lord");

		//var serverSmtp = configuration["Smtp:server2"];
		var serverSmtp = configuration.GetValue<string>("Smtp:server2");
	

        return Content(serverSmtp);
	}
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
		_productServisec.Add(
			new Product()
			{
				Title = model.Title,
				Description = model.Description,
			});
		await _uow.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

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


