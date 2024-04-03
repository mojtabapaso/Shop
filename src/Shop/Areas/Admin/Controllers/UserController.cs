using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Services.EFServices.Identity;
using Shop.ViewModels.Admin;

namespace Shop.Areas.Admin.Controllers;
[Authorize(Roles = "Admin")]

[Area(AreaConstants.AdminArea)]
public class UserController : Controller
{
    private readonly CustomeUserManager userManager;
    private readonly IConfiguration configuration;
    private readonly IMapper mapper;

    public UserController(CustomeUserManager userManager, IConfiguration configuration, IMapper mapper)
    {
        this.userManager = userManager;
        this.configuration = configuration;
        this.mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await userManager.GetAllUsersAsync();
        var usersViewModel = mapper.Map<List<UserViewModel>>(users);
        return View(usersViewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Detail(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            return RedirectToAction(nameof(Index), new { message = "User Not Found" });
        }
        var userViewModel = mapper.Map<UserViewModel>(user);
        return View(userViewModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserViewModel userViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userViewModel.UserName,
                Email = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                PhoneNumber = userViewModel.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var identityResult = await userManager.CreateAsync(user);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userViewModel);
            }
            var passwordResult = await userManager.AddPasswordAsync(user, userViewModel.Password);
            if (!passwordResult.Succeeded)
            {
                foreach (var error in passwordResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userViewModel);
            }
            return RedirectToAction(nameof(Index), new { message = "User created successfully!" });
        }

        return View(userViewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user != null)
        {
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreateDateTime = user.CreateDateTime,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
            };
            return View(userViewModel);
        }
        return RedirectToAction(nameof(Index), new { message = "User Not Found" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, UserViewModel userViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;
                user.PhoneNumber = userViewModel.PhoneNumber;

                if (userViewModel.Password != null)
                {
                    await userManager.RemovePasswordAsync(user);
                    await userManager.AddPasswordAsync(user, userViewModel.Password);
                }
                await userManager.UpdateSecurityStampAsync(user);
                var userUpdate = await userManager.UpdateAsync(user);
            }
            return RedirectToAction(nameof(Index), new { message = "User Not Found" });
        }
        return View(userViewModel);
    }
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        if (id != null)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index), new { message = "User Delete " });
            }
        }
        return RedirectToAction(nameof(Index), new { message = "User Not Found" });
    }
}
