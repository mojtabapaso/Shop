using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataLayer.context;
using Shop.Services.EFServices.Identity;
using Shop.Services.EntityContracts;

namespace Shop.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area(AreaConstants.AdminArea)]
public class CommentController : Controller
{
	private readonly ICommnetServisec commnetServisec;
	private readonly IUnitOfWork unitOfWork;
	private readonly CustomeUserManager customeUserManager;

	public CommentController(ICommnetServisec commnetServisec, IUnitOfWork unitOfWork, CustomeUserManager customeUserManager)
	{
		this.commnetServisec = commnetServisec;
		this.unitOfWork = unitOfWork;
		this.customeUserManager = customeUserManager;
	}
	[HttpGet("List")]
	public async Task<IActionResult> Index()
	{
		var comments = await commnetServisec.GetAllAsync();
		return View(comments);	
	}
}
