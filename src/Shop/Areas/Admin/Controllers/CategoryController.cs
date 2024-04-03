using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EFServices;
using Shop.Services.EntityContracts;
using Shop.ViewModels.Category;

namespace Shop.Areas.Admin.Controllers;
[Authorize(Roles = "Admin")]

public class CategoryController : Controller
{
	private readonly ICategoryServisec categoryServices;
	private readonly IMapper mapper;
	private readonly IUnitOfWork uow;

	public CategoryController(ICategoryServisec categoryServices,IMapper mapper,IUnitOfWork uow)
    {
		this.categoryServices = categoryServices;
		this.mapper = mapper;
		this.uow = uow;
	}
	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}
	[HttpGet]
	public async Task<IActionResult> Detail(string id)
	{
		var category = await categoryServices.FindByIdAsync(id);
		var categoryViewModel = mapper.Map<CategoryViewModel>(category);	
		return View(categoryViewModel);
	}
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost,ValidateAntiForgeryToken]
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
		await categoryServices.AddAsync(category);
		await uow.SaveChangesAsync();
		return View();
	}
}
