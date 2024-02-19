using Microsoft.AspNetCore.Mvc;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.Contracts.EntityContracts;
using Shop.ViewModels.Admin;

namespace Shop.Areas.Admin.Controllers;

//[Authorize(Roles = "Admin")]

[Area(AreaConstants.AdminArea)]
public class BrandController : Controller
{
    private readonly IBrandServisec brandServisec;
    private readonly IUnitOfWork uow;

    public BrandController(IUnitOfWork uow, IBrandServisec brandServisec)
    {
        this.uow = uow;
        this.brandServisec = brandServisec;
    }
    public async Task<IActionResult> Index(string message)
    {
        ViewData["Message"] = message;
        var brands = await brandServisec.GetAllAsync();
        return View(brands);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create(BrandViewModel brandViewModel)
    {
        if (ModelState.IsValid)
        {
            var brand = new Brand
            {
                Id = Guid.NewGuid().ToString(),
                Name = brandViewModel.Name
            };

            try
            {
                await brandServisec.AddAsync(brand);
                await uow.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "Brand created successfully!" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
            }
        }
        return View(brandViewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {

        if (id != null)
        {
            var brand = await brandServisec.FindByIdAsync(id);
            if (brand != null)
            {
                var brandViewModel = new BrandViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name
                };
                return View(brandViewModel);
            }
            else
            {
                return RedirectToAction("Index", new { message = "Brand not found!" });
            }
        }
        return RedirectToAction("Index", new { message = "Invalid brand ID!" });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Edit(BrandViewModel brandViewModel)
    {
        if (ModelState.IsValid)
        {
            var brand = await brandServisec.FindByIdAsync(brandViewModel.Id);
            if (brand != null)
            {
                brand.Name = brandViewModel.Name;
                try
                {
                    brandServisec.Update(brand);
                    await uow.SaveChangesAsync();
                    return RedirectToAction("Index", new { message = "Brand updated successfully!" });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Brand not found!");
            }
        }
        return View(brandViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return RedirectToAction("Index", new { message = $"Brand by id {id} is not delete !!!" });

        }
        brandServisec.Remove(id);
        await uow.SaveChangesAsync();
        return RedirectToAction("Index", new { message = $"Brand by id {id} is  delete seccess !!!" });

    }

}
