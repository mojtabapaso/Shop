using Microsoft.AspNetCore.Mvc;
using Nest;
using Shop.Entities;
using Shop.Services.Contracts.EntityContracts;
using Shop.ViewModels.Category;

namespace Shop.Areas.Admin.Controllers;

public class CategoryController : Controller
{
	private readonly CategoryServices categoryServices;

	public CategoryController(CategoryServices categoryServices)
    {
		this.categoryServices = categoryServices;
	}
    public IActionResult Index()
	{
		return View();
	}
	public async Task<IActionResult> Detail(string id)
	{
		var category = await categoryServices.FindByIdAsync(id);
		return View(category);
	}
	public IActionResult Create()
	{
		return View();
	}


	public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
	{
		var category = new Category
		{
			Id= new Guid().ToString(),
			Name = categoryViewModel.Name,
			IsSubCategory = categoryViewModel.IsSubCategory,
			Products = categoryViewModel.Products,
			SubCategories = categoryViewModel.SubCategories,
		};
		return View();
	}

}
