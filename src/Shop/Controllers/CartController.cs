using MongoDB.Bson;
using Shop.DataLayer.context;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities.MongoEntity;
using Shop.Services.EntityContracts;
using Microsoft.AspNetCore.Authorization;
using Shop.Services.Contracts.MongoContracts;
using Shop.Services.EFServices.Identity;


namespace Shop.Controllers;

[Authorize]
public class CartController : Controller
{
	private readonly IUnitOfWork uow;
	private readonly IProductServisec productServisec;
	private readonly IOrderServisec orderServisec;
	private readonly IHttpContextAccessor httpContextAccessor;
	private readonly IMongoCartServices mongoCartServices;
	private readonly CustomeUserManager userManager;

	public CartController(IHttpContextAccessor httpContextAccessor,
		IProductServisec productServisec,
		IOrderServisec orderServisec,
		IUnitOfWork uow,
		IMongoCartServices mongoCartServices,
		CustomeUserManager userManager)
	{
		this.httpContextAccessor = httpContextAccessor;
		this.productServisec = productServisec;
		this.orderServisec = orderServisec;
		this.uow = uow;
		this.mongoCartServices = mongoCartServices;
		this.userManager = userManager;
	}

	[HttpGet("Cart")]
	public async Task<IActionResult> Cart(string userId)
	{
		if (userId == null)
		{
			userId = userManager.GetUserId(User);
		}

		var cartBsons = await mongoCartServices.FindCartAsync(userId);
		List<CartItemMongo> cart = new List<CartItemMongo>();
		if (cartBsons != null)
		{
			var Items = cartBsons["Items"].AsBsonArray;

			foreach (var item in Items)
			{
				var cartItem = new CartItemMongo()
				{
					ProductId = item["ProductId"].ToString(),
					Price = item["Price"].ToDecimal(),
					ProductName = item["ProductName"].ToString(),
					Quantity = item["Quantity"].ToInt32(),

				};
				cart.Add(cartItem);
			}
		}

		ViewBag.Message = TempData["Message"];
		return View(cart);
	}
	[HttpPost, ValidateAntiForgeryToken]

	public async Task<IActionResult> Add(string productId)
	{
		var product = await productServisec.FindByIdAsync(productId);
		if (product == null)
		{
			return BadRequest();
		}
		var cartItem = new CartItemMongo
		{
			ProductId = product.Id,
			Price = product.Price,
			ProductName = product.Title,
			Quantity = 1,
			QuantityValid = product.Quantity,
		};
		var userId = userManager.GetUserId(User);
		await mongoCartServices.AddToCartAsync(cartItem.ToBsonDocument(), userId);
		return RedirectToAction(nameof(Cart), new { userId });
	}
	[HttpPost, ValidateAntiForgeryToken]

	public async Task<IActionResult> IncreaseCartItemQuantity(string productId)
	{
		var userId = userManager.GetUserId(User);
		var result = await mongoCartServices.IncreaseCartItemQuantityAsync(userId, productId);
		if (result.success)
		{
			return RedirectToAction(nameof(Cart), new { userId });
		}
		TempData["Message"] = result.message;
		return RedirectToAction(nameof(Cart), new { userId });
	}
	[HttpPost, ValidateAntiForgeryToken]

	public async Task<IActionResult> DecreaseCartItemQuantity(string productId)
	{
		var userId = userManager.GetUserId(User);
		await mongoCartServices.DecreaseCartItemQuantityAsync(userId, productId);
		return RedirectToAction(nameof(Cart), new { userId });
	}
	[HttpPost, ValidateAntiForgeryToken]

	public async Task<IActionResult> Remove(string productId)
	{
		var userId = userManager.GetUserId(User);
		await mongoCartServices.RemoveItemFromCartAsync(userId, productId);
		return RedirectToAction(nameof(Cart), new { userId });
	}
	[HttpPost, ValidateAntiForgeryToken]

	public async Task<IActionResult> RemoveAll(string id)
	{
		var userId = userManager.GetUserId(User);
		await mongoCartServices.RemoveCartAsync(userId);
		return RedirectToAction(nameof(Cart), new { userId });
	}
}
