using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.services.Contracts;

namespace Shop.Areas.Admin.Controllers;

public class ProductController : Controller
{
    private readonly IProductServisec productServisec;

    public ProductController(IProductServisec productServisec)
    {
        this.productServisec = productServisec;
    }
    public IActionResult Index()
    {
        return View();
    }

    // GET: ProductController/Details/5
    public IActionResult Details(int id)
    {
        var product = productServisec.FindById(id);
        return View(product);
    }

    // GET: ProductController/Create
    public IActionResult Create()
    {
        return View();
    }

    //POST: ProductController/Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    // public IActionResult Create(IFormCollection collection)
    // {
    //     try
    //     {
    //         return RedirectToAction(nameof(Index));
    //     }
    //     catch
    //     {
    //         return View();
    //     }
    // }

    // GET: ProductController/Edit/5
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
