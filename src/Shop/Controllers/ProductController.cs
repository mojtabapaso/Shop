using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.EntityContracts;
using Shop.ViewModels;
using Shop.ViewModels.Admin;

namespace Shop.Controllers;

public class ProductController : Controller
{
	private readonly IProductServisec productServisec;
	private readonly IMapper mapper;
	public ProductController(IProductServisec productServisec, IMapper mapper)
	{
		this.productServisec = productServisec;
		this.mapper = mapper;
	}
	[HttpGet("/Search")]
	public async Task<IActionResult> Search(string quary)
	{
		var products = await productServisec.SearchAsync(quary);
		var productsViewModel = mapper.Map<List<ProductViewModel>>(products);
		return View(productsViewModel);
	}
	[HttpGet]
	public async Task<IActionResult> List()
	{
		var products = await productServisec.GetAllAsync();

		if (products == null)
		{
			return View("NotFound");
		}
		var productsViewModel = mapper.Map<List<ProductViewModel>>(products);
		return View(productsViewModel);
	}
	[HttpGet]
	public async Task<IActionResult> Detail(string id)
	{
		var product = await productServisec.FindByIdWithModelCategoryAsync(id);
		if (product == null)
		{
			return View("NotFound");
		}
		var viewModel = new DetailProductAndCommnetViewModel
		{
			product = product,
		};
		return View(viewModel);
	}

}
