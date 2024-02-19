using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.Contracts.EntityContracts;
using Shop.ViewModels.Admin;

namespace Shop.Areas.Admin.Controllers;

//[Authorize(Roles = "Admin")]
[Area(AreaConstants.AdminArea)]

public class ProductController : Controller
{
	private readonly IProductServisec productServisec;
	private readonly IBrandServisec brandServisec;
	private readonly ICategoryServisec categoryServisec;
	private readonly ITagServisec tagServisec;
	private readonly IUnitOfWork uow;

	public ProductController(IProductServisec productServisec, IBrandServisec brandServisec,ICategoryServisec categoryServisec,
		ITagServisec tagServisec,
		IUnitOfWork uow)

	{
		this.productServisec = productServisec;
		this.brandServisec = brandServisec;
		this.categoryServisec = categoryServisec;
		this.tagServisec = tagServisec;
		this.uow = uow;
	}
	public IActionResult Index()
	{
		var products = productServisec.GetAll();
		return View(products);
	}

	[HttpGet]
	public IActionResult ListProduct()
	{
		var products = productServisec.GetAll();
		return View(products);
	}

	[HttpGet]
	public IActionResult Details(string id)
	{

		var product = productServisec.FindById(id);
		return View(product);
	}

	public async Task<IActionResult> Create()
	{
		var tags = await tagServisec.GetAllAsync();

		var model = new ProductViewModel
		{
			Tags = tags.Select(t => new SelectListItem
			{
				Text = t.Name,
				Value = t.Id,
			}).ToList(),
		};

		return View(model);
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(ProductViewModel productViewModel)
	{
		if (!ModelState.IsValid)
		{
			return View(productViewModel);
		}
		var product = new Product
		{
			Id = Guid.NewGuid().ToString(),
			Title = productViewModel.Title,
			Description = productViewModel.Description,
			Price = productViewModel.Price,
			Quantity = productViewModel.Quantity,
			Status = productViewModel.Status,
			Color = productViewModel.Color,
			Model = productViewModel.Model,
			Weight = productViewModel.Weight,
			Manufacturer = productViewModel.Manufacturer,
		};
		List<Tag> listTag = new List<Tag>();
		foreach (var tagId in productViewModel.Tag)
		{
			var tag = await tagServisec.FindByIdAsync(tagId);
			if (tag != null)
			{
				listTag.Add(tag);
			}
			else
			{
				return NotFound();
			}
		}

		//product.Brand = await brandServisec.FindByIdAsync(productViewModel.Brand);
		//product.SlugGenerator();

		product.Tags.AddRange(listTag);
		productServisec.Add(product);
		var resultSvae = await uow.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	public IActionResult Edit(int id)
	{
		return View();
	}

	// POST: ProductController/Edit/5
	//[HttpPost]
	//[ValidateAntiForgeryToken]
	//public IActionResult Edit(int id, IFormCollection collection)
	//{
	//    try
	//    {
	//        return RedirectToAction(nameof(Index));
	//    }
	//    catch
	//    {
	//        return View();
	//    }
	//}

	// GET: ProductController/Delete/5
	public IActionResult Delete(int id)
	{
		return View();
	}

	//// POST: ProductController/Delete/5
	//[HttpPost]
	//[ValidateAntiForgeryToken]
	//public IActionResult Delete(int id, IFormCollection collection)
	//{
	//    try
	//    {
	//        return RedirectToAction(nameof(Index));
	//    }
	//    catch
	//    {
	//        return View();
	//    }
	//}
}
