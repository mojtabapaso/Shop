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
	[HttpPost]
	public async Task<IActionResult> Coupon(string coupon)
	{

		var userId = userManager.GetUserId(User);
		bool validateStatus = await mongoCouponServices.ValidateCouponAsync(userId, coupon);
		if (validateStatus == false)
		{
			return Json(false);
		}
		return Json(true);
	}

	[HttpPost]
	public async Task<IActionResult> Payment(string priceCart)
	{
		if (priceCart == null)
		{
			return Json(false);
		}
		TempData["TotalPrice"] = priceCart;
		return Json(true);
		//var user = await userManager.GetUserAsync(User);
		//var phoneNumber = user.PhoneNumber;
		//var payment = await paymentServisec.PaymentAsync(totalprice, "/", phoneNumber, "Description");

		//if (payment.IsSuccessStatusCode)
		//{
		//	List<ItemCart> cart = new List<ItemCart>();

		//	var cartBsons = await mongoCartServices.FindCartAsync(user.Id);
		//	var Items = cartBsons["Items"].AsBsonArray;
		//	foreach (var item in Items)
		//	{
		//		var cartItem = new ItemCart()
		//		{
		//			Quantity = item["Quantity"].ToInt32(),
		//			Product = await productServisec.FindByIdAsync(item["ProductId"].ToString())
		//		};
		//		cart.Add(cartItem);
		//	}
		//	var order = new Order
		//	{
		//		Id = Guid.NewGuid().ToString(),
		//		IsPament = true,
		//		ItemsCart = cart,
		//		OrderDate = DateTime.Now,
		//		TotalPrice = totalprice,
		//		User = user,
		//	};
		//	await orderServisec.AddAsync(order);
		//	await uow.SaveChangesAsync();
		//}
		//return RedirectToAction("Index", "Home");
	}
}
