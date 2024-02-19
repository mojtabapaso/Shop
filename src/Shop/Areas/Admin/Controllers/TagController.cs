using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.Contracts.EntityContracts;
using Shop.Services.EFServices;
using Shop.ViewModels.Admin;

namespace Shop.Areas.Admin.Controllers;
//[Authorize(Roles = "Admin")]

[Area(AreaConstants.AdminArea)]
public class TagController : Controller
{
	private readonly ITagServisec tagServisec;
	private readonly IUnitOfWork uow;
	private readonly ILogger<TagController> logger;
    private readonly IProductServisec productServisec;

    public TagController(ITagServisec tagServisec, IUnitOfWork uow, ILogger<TagController> logger,IProductServisec productServisec)
	{
		this.tagServisec = tagServisec;
		this.uow = uow;
		this.logger = logger;
        this.productServisec = productServisec;
    }
	public async Task<IActionResult> Index(string message)
	{
		ViewData["Message"] = message;

		var tags = await tagServisec.GetAllAsync();
		
		var listTags = new List<TagViewModel>();

		foreach (var item in tags)
		{
			listTags.Add(new TagViewModel
			{
				Id = item.Id,
				Name = item.Name,
				Products = item.Products,
			});
		}
		return View(listTags);
	}
	//public async Task<IActionResult> Details(string id)
	//{
	//    var tag = await tagServisec.FindByIdAsync(id);
	//    var tagViewModel = new TagViewModel
	//    {
	//        Id = tag.Id,
	//        Name = tag.Name,
	//    };
	//    return View(tagViewModel);
	//}
	public IActionResult Create()
	{
		//var tagModel = tagServisec.GetAll();
		var productModel = productServisec.GetAll();
		//List<Product> listProducts = new List<Product>();
		//foreach (var item in productModel)
		//{
		//listProducts.AddRange(item.Products);
		//}
		var tagViewModel = new TagViewModel
		{
			selectListItemProducts = productModel.Select(p => new SelectListItem { Text = p.Title, Value = p.Id }).ToList(),
		};
		return View(tagViewModel);
	}
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(TagViewModel tagViewModel)
	{
		if (ModelState.IsValid)
		{
			var tag = new Tag
			{
				Id = Guid.NewGuid().ToString(),
				Name = tagViewModel.Name,
			};
			try
			{
				await tagServisec.AddAsync(tag);
				await uow.SaveChangesAsync();
				logger.LogInformation("Tag created successfully");

				return RedirectToAction("Index", new { message = "Brand created successfully!" });
			}
			catch (Exception ex)
			{
				logger.LogCritical("Unexpected error creating tag", ex);
				ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
			}
		}
		return View(tagViewModel);
	}
	public async Task<IActionResult> Edit(string id)
	{
		if (id == null)
		{
			logger.LogWarning("Edit action called with null ID.");
			return RedirectToAction("Index", new { message = "Invalid tag ID!" });
		}
		if (id != null)
		{
			var tag = await tagServisec.FindByIdAsync(id);

			if (tag != null)
			{
				logger.LogInformation($"Tag found for editing: {id}");
				var tagViewModel = new TagViewModel
				{
					Id = tag.Id,
					Name = tag.Name
				};
				return View(tagViewModel);
			}
			else
			{
				return RedirectToAction("Index", new { message = "Tag not found!" });
			}
		}
		return RedirectToAction("Index", new { message = "Tag brand ID!" });
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(string id, TagViewModel tagViewModel)
	{
		if (id == null)
		{
			logger.LogWarning("Tag id is null for edit ");
			return RedirectToAction("Index", new { message = "id is null" });

		}
		if (ModelState.IsValid)
		{
			var tag = await tagServisec.FindByIdAsync(id);
			if (tag != null)
			{
				tag.Name = tagViewModel.Name;
				try
				{
					tagServisec.Update(tag);
					await uow.SaveChangesAsync();
					logger.LogInformation("Save tag success");

					return RedirectToAction("Index", new { message = "Tag updated successfully!" });
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Tag not found!");
			}
		}
		return View(tagViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Delete(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			logger.LogWarning($"Tag not found for delete: {id}");

			return RedirectToAction("Index", new { message = $"Brand by id {id} is not delete !!!" });
		}
		tagServisec.Remove(id);
		await uow.SaveChangesAsync();

		return RedirectToAction("Index", new { message = $"Brand by id {id} is  delete seccess !!!" });

	}
}
