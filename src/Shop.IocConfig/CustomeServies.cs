using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.DataLayer.context;
using Shop.services.Contracts;
using Microsoft.Extensions.Configuration;
using Shop.services;
using Microsoft.EntityFrameworkCore.Design;
using Shop.Services.Contracts;
using Shop.Services;
using Shop.Services.EFServices;
using Shop.Mappings;

namespace Shop.IocConfig;

public static class CustomeServies
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
		services.AddAutoMapper(typeof(MappingProfile));	
		services.AddScoped<IKaveNegarServic, KaveNegarServic>();
		services.AddScoped<IAws3Services, Aws3Services>();
		services.AddScoped<IPaymentServisec, PaymentServisec>();

		services.AddSingleton<IDesignTimeDbContextFactory<ShopDbContext>, ApplicationDbContextFactory>();

		return services;
	}

}