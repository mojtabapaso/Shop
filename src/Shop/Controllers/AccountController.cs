using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Common.Generator;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.services.Contracts;
using Shop.ViewModels.Account;

namespace Shop.Controllers;

public class AccountController : Controller
{
	private readonly CustomeUserManager userManager;
	private readonly SignInManager<User> signInManager;
	private readonly IKaveNegarServic kaveNegarServic;
	private readonly IConfiguration configuration;
	private readonly IMongoDbAuthenticationServices mongoDbAuthenticationServices;
	private readonly IUnitOfWork uow;
	private readonly ILogger<AccountController> logger;

	public AccountController(
	CustomeUserManager userManager,

	IKaveNegarServic kaveNegarServic,
	IConfiguration configuration,
	IUnitOfWork uow,
	IMongoDbAuthenticationServices mongoDbAuthenticationServices,
	ILogger<AccountController> logger,
	SignInManager<User> signInManager)
	{
		this.userManager = userManager;
		this.kaveNegarServic = kaveNegarServic;
		this.configuration = configuration;
		this.mongoDbAuthenticationServices = mongoDbAuthenticationServices;
		this.uow = uow;
		this.logger = logger;
		this.signInManager = signInManager;
	}
	[HttpGet]
	public IActionResult Auth(string? returnUrl)
	{
		if (returnUrl != null)
			TempData["returnUrl"] = returnUrl;

		return View();
	}
	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
	{
		List<string> errors = new List<string>();
		if (ModelState.IsValid)
		{
			string code = GeneratorRandomeCode.RandomeCode(6);
			kaveNegarServic.SendCodeToPhoneNumber(code, registerViewModel.PhoneNumber);
			await mongoDbAuthenticationServices.CreateAuthUserAsync(registerViewModel.PhoneNumber, code);

			return RedirectToAction(nameof(RegisterOTPCode), new { phoneNumber = registerViewModel.PhoneNumber });

		}
		return BadRequest(errors);
	}
	[HttpGet]
	public IActionResult RegisterOTPCode(string phoneNumber)
	{
		if (phoneNumber == null)
		{
			return BadRequest();
		}
		ViewData["phoneNumber"] = phoneNumber;
		return View();
	}


	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> RegisterOTPCode(CodeOTPViewModel codeOTPViewModel)
	{
		if (ModelState.IsValid && await mongoDbAuthenticationServices.PhoneNumberIsValidAsync(codeOTPViewModel.PhoneNumber))
		{
			var otp = await mongoDbAuthenticationServices.GetUserByPhoneNumberAsync(codeOTPViewModel.PhoneNumber);
			if (otp != null)
			{
				var phoneNumber = otp.GetElement("PhoneNumber").Value.AsString;
				var code = otp.GetElement("Code").Value.AsString;
				if (code == codeOTPViewModel.Code)
				{
					var user = new User()
					{
						UserName = phoneNumber,
						PhoneNumber = phoneNumber,
						PhoneNumberConfirmed = true,
					};
					await userManager.CreateAsync(user);
					var ss = await uow.SaveChangesAsync();
				}
				else if (code != codeOTPViewModel.Code)
				{
					await mongoDbAuthenticationServices.AddTryAsync(codeOTPViewModel.PhoneNumber);
					return View();
				}
			}
		}
		return BadRequest();
	}


	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}
	[HttpPost,ValidateAntiForgeryToken]

	public async Task<IActionResult> Login(LoginViewModel loginViewModel)
	{
		if (!ModelState.IsValid)
			return View(loginViewModel);
		var user = await userManager.FindByPhoneNumberAsync(loginViewModel.PhoneNumber);
		if (user == null)
		{
			ModelState.AddModelError("", "شمراه تلفن شما یافت نشد ");
			return View(loginViewModel);
		}

		string code = GeneratorRandomeCode.RandomeCode(6);
		await mongoDbAuthenticationServices.CreateAuthUserAsync(loginViewModel.PhoneNumber, code);

		return RedirectToAction(nameof(LoginOTP), new { phoneNumber = loginViewModel.PhoneNumber });
	}

	[HttpGet]
	public IActionResult LoginOTP(string phoneNumber)
	{
		if (string.IsNullOrEmpty(phoneNumber))
		{
			return BadRequest();
		}
		ViewData["phoneNumber"] = phoneNumber;
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> LoginOTP(CodeOTPViewModel codeOTPViewModel)
	{
		if (!ModelState.IsValid)
			return View(codeOTPViewModel);

		var user = await userManager.FindByPhoneNumberAsync(codeOTPViewModel.PhoneNumber);
		await signInManager.SignInAsync(user, true, null);
		return RedirectToAction("Index", "Home");

	}


	public async Task<IActionResult> Logout()
	{
		await signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}

	[HttpPost]
	public JsonResult RegexValidatePhoneNumber(string phoneNumber)
	{
		if (Regex.IsMatch(phoneNumber, @"^09\d{9}$"))
			return Json(true);
		return Json(false);
	}

	[HttpPost]
	public JsonResult CheckUserName(string userName)
	{
		var user = userManager.FindByPhoneNumberAsync(userName);
		if (user != null)
			return Json(true);
		return Json(false);
	}
}
