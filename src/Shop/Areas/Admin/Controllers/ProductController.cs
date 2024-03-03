using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services;
using Shop.Services.Contracts;
using Shop.Services.EntityContracts;
using Shop.ViewModels.Admin;

namespace Shop.Areas.Admin.Controllers;

[Area(AreaConstants.AdminArea)]

//[Authorize(Roles = "Admin")]
//  Admin/Product
public class ProductController : Controller
{
    private readonly IProductServisec productServisec;
	private readonly IMapper mapper;
	private readonly IBrandServisec brandServisec;
    private readonly IAws3Services aws3Services;
    private readonly ICategoryServisec categoryServisec;
    private readonly ITagServisec tagServisec;
    private readonly IUnitOfWork uow;


    public ProductController(IProductServisec productServisec,
        IMapper mapper,
        IBrandServisec brandServisec,
        IAws3Services aws3Services,
        ICategoryServisec categoryServisec,
        ITagServisec tagServisec,
        IUnitOfWork uow)
    {
        this.productServisec = productServisec;
		this.mapper = mapper;
		this.brandServisec = brandServisec;
        this.aws3Services = aws3Services;
        this.categoryServisec = categoryServisec;
        this.tagServisec = tagServisec;
        this.uow = uow;
    }
	//[HttpGet]
	public async Task<IActionResult> Index()
    {
        var products = await productServisec.GetAllWithAllRelatedModelsAsync();

        return View(products);
    }

    //[HttpGet]
    public IActionResult Detail(string id)
    {

        var product = productServisec.FindById(id);
        var mapProduct = mapper.Map<Product>(product);

		return View(mapProduct);
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
        var ss = await aws3Services.UploadFileAsync(productViewModel.ImageFile);
        product.ImagePath = ss;

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
		product.Brand = await brandServisec.FindByIdAsync(productViewModel.Brand);
		product.Tags.AddRange(listTag);
        productServisec.Add(product);
         
        var resultSvae = await uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string id)
    {
        var product = await productServisec.FindByIdWithAllRelatedModelsAsync(id);
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        productServisec.Remove(id);
        await uow.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
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
