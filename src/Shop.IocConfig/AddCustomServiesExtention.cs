using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Shop.DataLayer.context;
using Shop.Services.Contracts;
using Shop.Services.EFServices;
using Shop.ViewModels.App;
using Shop.Entities;
using Microsoft.Extensions.Configuration;
using Shop.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Design;
using Shop.Services.MongoServices;
using Microsoft.AspNetCore.Identity;
using System.Security.AccessControl;

namespace Shop.IocConfig;

public static class AddCustomServiesExtention
{
	public static IServiceCollection AddCustomeServies(this IServiceCollection services)
	{
		IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
		IConfigurationRoot root = builder.Build();

		string? KaveNegarAPI = root["KaveNegarAPI:APIKey"];
		string? sqlConnectionString = root["ConnectionStrings:DatabaseSQL:ShopDbContextConnection"];

    
        var provider = services.BuildServiceProvider();

		services.AddDbContext<ShopDbContext>(option =>
		{
			option.UseSqlite(sqlConnectionString);
		});
        

        services.AddScoped<IUnitOfWork, ShopDbContext>();
		services.AddScoped<IProductServisec, ProductServisec>();
        services.AddScoped<IKaveNegarServic, KaveNegarServic>();
        services.AddScoped<IMongoDbAuthenticationServices, MongoDbAuthenticationServices>();
        services.AddSingleton<IDesignTimeDbContextFactory<ShopDbContext>, ApplicationDbContextFactory>();
        
		services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		.AddCookie(options =>
		{
			options.Cookie.HttpOnly = true;
			options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
			options.LoginPath = "/Account/Auth";
			options.AccessDeniedPath = "/Account/AccessDenied";
			options.SlidingExpiration = true;
		});

		services.AddIdentity<User, Role>()
		//services.AddIdentityCore<User>().AddRoles<Role>()
		.AddUserManager<UserManager<User>>()
		.AddPasswordValidator<PasswordValidator<User>>()
		.AddDefaultTokenProviders()
		.AddUserManager<CustomeUserManager>()
		.AddEntityFrameworkStores<ShopDbContext>();

		//.AddSignInManager<CustomeSignInManager>()


		return services;
	}
}