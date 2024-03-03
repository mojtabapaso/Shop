using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EFServices.Identity;
using Shop.Services.EntityContracts;
using Shop.ViewModels;

namespace Shop.Controllers;
[Authorize]
public class AddressController : Controller
{
	private readonly IAddressServisec addressServisec;
	private readonly IUnitOfWork uow;
	private readonly IMapper mapper;
	private readonly CustomeUserManager userManager;

	public AddressController(IAddressServisec addressServisec, IUnitOfWork uow,
		IMapper mapper,
		CustomeUserManager userManager)
	{
		this.addressServisec = addressServisec;
		this.uow = uow;
		this.mapper = mapper;
		this.userManager = userManager;
	}
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Create(AddressViewModel addressViewModel)
	{
		string userId = userManager.GetUserId(User);
		var address = new Address()
		{
			Id = Guid.NewGuid().ToString(),
			Title = addressViewModel.Title,
			HouseNumber = addressViewModel.HouseNumber,
			PostalCode = addressViewModel.PostalCode,
			Text = addressViewModel.Text,
			UserId = userId,
		};
		await addressServisec.AddAsync(address);
		var user = await userManager.FindByIdAsync(userId);
		user.Addresses.Add(address);

		await uow.SaveChangesAsync();
		return RedirectToAction("List");
	}

	public async Task<IActionResult> List()
	{
		var userId = userManager.GetUserId(User);
		var addressList = await addressServisec.GetAllAddressByIdUser(userId);
		var addressViewModels = mapper.Map<List<AddressViewModel>>(addressList);
		return View(addressViewModels);
	}
}
