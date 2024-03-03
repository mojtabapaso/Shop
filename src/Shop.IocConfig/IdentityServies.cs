using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EFServices.Identity;

namespace Shop.IocConfig;
public static class IdentityServies
{
	public static IServiceCollection AddIdentityServies(this IServiceCollection services)
	{

		services.AddIdentity<User, Role>()
		//services.AddIdentityCore<User>().AddRoles<Role>()
		.AddUserManager<UserManager<User>>()
		.AddPasswordValidator<PasswordValidator<User>>()
		.AddDefaultTokenProviders()
		.AddUserManager<CustomeUserManager>()
		.AddEntityFrameworkStores<ShopDbContext>();

		services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		.AddCookie(options =>
		{
			options.Cookie.HttpOnly = true;
			options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
			options.LoginPath = "/Account/Auth";
			options.AccessDeniedPath = "/";
			options.SlidingExpiration = true;
		});
		return services;

	}

}
