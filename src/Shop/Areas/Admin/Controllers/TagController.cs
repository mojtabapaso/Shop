using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;
using Shop.ViewModels.Admin;

namespace Shop.Areas.Admin.Controllers;
[Authorize(Roles = "Admin")]

[Area(AreaConstants.AdminArea)]
public class TagController : Controller
{
	private readonly ITagServisec tagServisec;
	private readonly IUnitOfWork uow;
	private readonly ILogger<TagController> logger;
	private readonly IProductServisec productServisec;
	private readonly IMapper mapper;

	public TagController(ITagServisec tagServisec, IUnitOfWork uow, ILogger<TagController> logger, IProductServisec productServisec, IMapper mapper)
	{
		this.tagServisec = tagServisec;
		this.uow = uow;
		this.logger = logger;
		this.productServisec = productServisec;
		this.mapper = mapper;
	}
	[HttpGet]
	public async Task<IActionResult> Index(string message)
	{
		ViewData["Message"] = message;

		var tags = await tagServisec.GetAllAsync();

		var listTags = mapper.Map<List<TagViewModel>>(tags);

		return View(listTags);
	}
	[HttpGet]
	public IActionResult Create()
	{
		var productModel = productServisec.GetAll();
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
		if (!ModelState.IsValid)
		{
			return View(tagViewModel);
		}
		var tag = new Tag
		{
			Id = Guid.NewGuid().ToString(),
			Name = tagViewModel.Name,
		};
		List<Product> listProduct = new List<Product>();
		if (tagViewModel.ProductId != null)
		{
			foreach (var item in tagViewModel.ProductId)
			{
				var product = await productServisec.FindByIdAsync(item);
				if (product != null)
				{
					listProduct.Add(product);
				}
			}
			tag.Products = listProduct;
		}

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
		return RedirectToAction("Index", new { message = "Brand created successfully!" });

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
				var tagViewModel = mapper.Map<TagViewModel>(tag);

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
