using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.DataLayer.context;
using Shop.services.Contracts;
using Shop.services.EFServices;
using Shop.Entities;
using Microsoft.Extensions.Configuration;
using Shop.services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Design;
using Shop.services.MongoServices;
using Microsoft.AspNetCore.Identity;

namespace Shop.IocConfig;

public static class AddCustomServiesExtention
{
	public static IServiceCollection AddCustomeServies(this IServiceCollection services)
	{
		IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
		IConfigurationRoot root = builder.Build();
		IConfiguration Configuration;
		string? KaveNegarAPI = root["KaveNegarAPI:APIKey"];
		string? sqlConnectionString = root["ConnectionStrings:DatabaseSQL:ShopDbContextConnection"];

		services.AddDbContext<ShopDbContext>(option =>
		{
			option.UseSqlite(sqlConnectionString);
		});

		services.AddScoped<IUnitOfWork, ShopDbContext>();
		services.AddScoped<IProductServisec, ProductServisec>();
		services.AddScoped<IKaveNegarServic, KaveNegarServic>();
		services.AddScoped<IMongoDbAuthenticationServices, MongoDbAuthenticationServices>();
		services.AddSingleton<IDesignTimeDbContextFactory<ShopDbContext>, ApplicationDbContextFactory>();

		services.AddIdentity<User, IdentityRole>()
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
		//services.Configure<ConnectionStringMongo>(Configuration.GetSection("TestDI"));

		//.AddSignInManager<CustomeSignInManager>()

		return services;
	}
}