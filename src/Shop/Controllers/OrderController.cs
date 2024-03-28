using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataLayer.context;
using Shop.Services.Contracts.MongoContracts;
using Shop.Services.EFServices;
using Shop.Services.EFServices.Identity;
using Shop.Services.EntityContracts;
using Shop.Services.MongoContracts;

namespace Shop.Controllers;

[Authorize]
public class OrderController : Controller
{
	private readonly IMongoCouponServices mongoCouponServices;
	private readonly IMongoCartServices mongoCartServices;
	private readonly IPaymentServisec paymentServisec;
	private readonly IProductServisec productServisec;
	private readonly IAddressServisec addressServisec;
	private readonly IOrderServisec orderServisec;
	private readonly CustomeUserManager userManager;
	private readonly IUnitOfWork uow;

	public OrderController(IPaymentServisec paymentServisec,
		IMongoCouponServices mongoCouponServices,
		IMongoCartServices mongoCartServices,
		IProductServisec productServisec,
		IAddressServisec addressServisec,
		CustomeUserManager userManager,
		IOrderServisec orderServisec,
		IUnitOfWork uow
		)
	{
		this.mongoCouponServices = mongoCouponServices;
		this.mongoCartServices = mongoCartServices;
		this.paymentServisec = paymentServisec;
		this.addressServisec = addressServisec;
		this.productServisec = productServisec;
		this.orderServisec = orderServisec;
		this.userManager = userManager;
		this.uow = uow;
	}


	public async Task<IActionResult> Payment()
	{
		var addresses = await addressServisec.GetAllAsync();

		return View(addresses);
	}
	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Coupon(string coupon)
	{

		var userId = userManager.GetUserId(User);
		//bool validateStatus = await mongoCouponServices.ValidateCouponAsync(userId, coupon);
		//if (validateStatus == false)
		//{
		//	return Json(false);
		//}
		await mongoCouponServices.SetCoponAsync(userId, coupon);
		return Json(true);
	}

	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Payment(string priceCart)
	{
		if (priceCart == null)
		{
			return Json(false);
		}
		TempData["TotalPrice"] = priceCart;
		return Json(true);
	}
}
