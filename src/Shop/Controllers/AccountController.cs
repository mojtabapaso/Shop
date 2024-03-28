using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Common.Generator;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.services.Contracts;
using Shop.Services.Contracts.MongoContracts;
using Shop.Services.EFServices.Identity;
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
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
	{
		if (!ModelState.IsValid)
		{
			return View(registerViewModel);

		}
		var user = await userManager.FindByPhoneNumberAsync(registerViewModel.PhoneNumber);
		if (user != null)
		{
			ModelState.AddModelError(string.Empty, "User already exist");
			return View(registerViewModel);
		}

		string code = GeneratorRandomeCode.RandomeCode(6);
		kaveNegarServic.SendCodeToPhoneNumber(code, registerViewModel.PhoneNumber);
		await mongoDbAuthenticationServices.CreateAuthUserAsync(registerViewModel.PhoneNumber, code);

		return RedirectToAction(nameof(RegisterOTPCode), new { phoneNumber = registerViewModel.PhoneNumber });
	}
	[HttpGet]
	public IActionResult RegisterOTPCode(string phoneNumber)
	{
		if (phoneNumber == null)
		{
			return View(nameof(Register));
		}
		ViewData["phoneNumber"] = phoneNumber;
		return View();
	}


	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> RegisterOTPCode(CodeOTPViewModel codeOTPViewModel)
	{
		if (!ModelState.IsValid)
		{
			return View(codeOTPViewModel);
		}
		var validatePhoneNumbner = await mongoDbAuthenticationServices.PhoneNumberIsValidAsync(codeOTPViewModel.PhoneNumber);
		if (validatePhoneNumbner == false)
		{
			ModelState.AddModelError(string.Empty, "Code is invalid");
			return View(codeOTPViewModel);
		}
		var otp = await mongoDbAuthenticationServices.GetUserByPhoneNumberAsync(codeOTPViewModel.PhoneNumber);
		if (otp == null)
		{
			ModelState.AddModelError(string.Empty, "Code is invalid");
			return View(codeOTPViewModel);
		}
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
			await signInManager.SignInAsync(user, true, null);

			await uow.SaveChangesAsync();
		}
		else if (code != codeOTPViewModel.Code)
		{
			await mongoDbAuthenticationServices.AddTryAsync(codeOTPViewModel.PhoneNumber);
			ModelState.AddModelError(string.Empty, "Please try again , Code is invalid");
			return View(codeOTPViewModel);
		}
		return RedirectToAction("Index", "Home");
	}


	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(LoginViewModel loginViewModel)
	{
		if (!ModelState.IsValid)
			return View(loginViewModel);
		var user = await userManager.FindByPhoneNumberAsync(loginViewModel.PhoneNumber);
		if (user == null)
		{
			ModelState.AddModelError(string.Empty, "Phone number is invalid.");
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
			return View("Error");
		}
		ViewData["phoneNumber"] = phoneNumber;
		return View();
	}
	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> LoginOTP(CodeOTPViewModel codeOTPViewModel)
	{
		if (!ModelState.IsValid)
			return View(codeOTPViewModel);

		var user = await userManager.FindByPhoneNumberAsync(codeOTPViewModel.PhoneNumber);
		if (user is null)
		{
			ModelState.AddModelError(string.Empty, "User not found");
			return View(codeOTPViewModel);
		}
		await signInManager.SignInAsync(user, true, null);
		return RedirectToAction("Index", "Home");

	}
	[HttpGet]
	public IActionResult LoginByPassword()
	{
		return View();
	}
	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> LoginByPassword(LoginByPasswordViewModel loginByPasswordViewModel)
	{
		if (!ModelState.IsValid)
		{
			return View(loginByPasswordViewModel);
		}

		var user = await userManager.FindByPhoneNumberAsync(loginByPasswordViewModel.PhoneNumber);

		if (user is null)
		{
			ModelState.AddModelError(string.Empty, "Invalid phone number or password.");
			return View(loginByPasswordViewModel);
		}

		var signInResult = await signInManager.CheckPasswordSignInAsync(user, loginByPasswordViewModel.Password, false); // Use lockoutOnFailure: false

		if (!signInResult.Succeeded)
		{
			ModelState.AddModelError(string.Empty, "Invalid phone number or password.");
			return View(loginByPasswordViewModel);
		}

		await signInManager.SignInAsync(user, isPersistent: loginByPasswordViewModel.RememberMe);
		return RedirectToAction("Index", "Home");

	}

	[Authorize]
	[HttpGet]
	public IActionResult ChangePassword()
	{
		return View();
	}
	[Authorize]
	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
	{
		if (!ModelState.IsValid)
		{
			return View(changePasswordViewModel);
		}

		var user = await userManager.GetUserAsync(User);

		if (!await userManager.CheckPasswordAsync(user, changePasswordViewModel.OldPassword))
		{
			ModelState.AddModelError("OldPassword", "رمز عبور فعلی اشتباه است.");
			return View(changePasswordViewModel);
		}

		var result = await userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);

		if (result.Succeeded)
		{
			await signInManager.SignInAsync(user, isPersistent: false);
			return RedirectToAction("Index", "Home");
		}
		else
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
			return View(changePasswordViewModel);
		}
	}
	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Logout()
	{
		await signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}

	[HttpPost, ValidateAntiForgeryToken]

	public IActionResult ExternalLogin(string ReturnUrl)
	{
		string url = Url.Action(nameof(CallBack), "Account", new
		{
			ReturnUrl
		});
		var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", url);
		return new ChallengeResult("Google", properties);
	}
	[HttpPost, ValidateAntiForgeryToken]

	public async Task<IActionResult> CallBack(string ReturnUrl)
	{
		var loginInfo = await signInManager.GetExternalLoginInfoAsync();
		string email = loginInfo.Principal.FindFirst(ClaimTypes.Email)?.Value ?? null;
		if (string.IsNullOrEmpty(email))
		{
			return BadRequest();
		}
		string name = loginInfo.Principal.FindFirst(ClaimTypes.GivenName)?.Type ?? null;



		var sigin = await signInManager.ExternalLoginSignInAsync("Google", loginInfo.ProviderKey, false, true);
		if (sigin.Succeeded)
		{
			if (Url.IsLocalUrl(ReturnUrl))
			{

				return Redirect("~/");
			}
			return RedirectToAction("Index", "Home");
		}
		var user = await userManager.FindByEmailAsync(email);

		if (user == null)
		{
			User newUser = new User
			{
				UserName = name,
				Email = email
			};
			var resultAddress = await userManager.CreateAsync(newUser);
			user = newUser;
		}
		await userManager.AddLoginAsync(user, loginInfo);
		await signInManager.SignInAsync(user, false);
		return Redirect("~/");
	}
	[HttpPost, ValidateAntiForgeryToken]
	public JsonResult RegexValidatePhoneNumber(string phoneNumber)
	{
		if (Regex.IsMatch(phoneNumber, @"^09\d{9}$"))
			return Json(true);
		return Json(false);
	}

	[HttpPost, ValidateAntiForgeryToken]
	public JsonResult CheckUserName(string userName)
	{
		var user = userManager.FindByPhoneNumberAsync(userName);
		if (user != null)
			return Json(true);
		return Json(false);
	}


}
