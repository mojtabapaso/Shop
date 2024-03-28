using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EFServices.Identity;
using Shop.Services.EntityContracts;
using Shop.ViewModels;

namespace Shop.Controllers;

public class CommentController : Controller
{
	private readonly ICommnetServisec commnetServisec;
	private readonly IProductServisec productServisec;
	private readonly IHttpContextAccessor httpContextAccessor;
	private readonly CustomeUserManager userManager;
	private readonly IUnitOfWork uow;

	public CommentController(ICommnetServisec commnetServisec,
		IProductServisec productServisec,
		IHttpContextAccessor httpContextAccessor,
		CustomeUserManager userManager,
		IUnitOfWork uow)
	{
		this.commnetServisec = commnetServisec;
		this.productServisec = productServisec;
		this.httpContextAccessor = httpContextAccessor;
		this.userManager = userManager;
		this.uow = uow;
	}
	[HttpPost, ValidateAntiForgeryToken]
	[Authorize]
	public async Task<IActionResult> Create(CommentViewModel commentViewModel)
	{
		if (commentViewModel == null)
		{
			// need change
			return View("Error");
		}
		if (!ModelState.IsValid)
		{
			return View(commentViewModel);
		}
		var commnet = new Comment
		{
			Id = Guid.NewGuid().ToString(),
			Text = commentViewModel.Text,
		};
		var product = await productServisec.FindByIdAsync(commentViewModel.ProductId);
		var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

		if (product is null || user is null)
		{
			// need change
			return NotFound();
		}

		commnet.Product = product;
		commnet.User = user;

		await commnetServisec.AddAsync(commnet);
		await uow.SaveChangesAsync();
		return View(commentViewModel);
	}
}
