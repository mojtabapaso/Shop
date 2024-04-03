using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EFServices.Identity;
using Shop.Services.EntityContracts;
using Shop.ViewModels;

namespace Shop.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area(AreaConstants.AdminArea)]
public class CommentController : Controller
{
	private readonly ICommnetServisec commnetServisec;
	private readonly IUnitOfWork unitOfWork;
	private readonly CustomeUserManager customeUserManager;
	private readonly IMapper mapper;

	public CommentController(ICommnetServisec commnetServisec, IUnitOfWork unitOfWork, CustomeUserManager customeUserManager,IMapper mapper)
	{
		this.commnetServisec = commnetServisec;
		this.unitOfWork = unitOfWork;
		this.customeUserManager = customeUserManager;
		this.mapper = mapper;
	}
	[HttpGet("List")]
	public async Task<IActionResult> Index()
	{
		var comments = await commnetServisec.GetAllAsync();
		var commentsViewModel = mapper.Map<List<CommentViewModel>>(comments);
		return View(commentsViewModel);	
	}
}
