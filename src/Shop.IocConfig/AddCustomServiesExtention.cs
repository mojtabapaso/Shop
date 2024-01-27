using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Shop.DataLayer.context;
using Shop.Services.Contracts;
using Shop.Services.EFServices;
using Shop.ViewModels.App;
using Microsoft.Extensions.Configuration;

namespace Shop.IocConfig;

public static class AddCustomServiesExtention
{
	
	public static IServiceCollection AddCustomeServies(this IServiceCollection services, IConfiguration Configuration)

	{
		var provider = services.BuildServiceProvider();
		var connectionString = provider.GetRequiredService<IOptionsMonitor<ConnectionStrings>>().CurrentValue;

		services.AddDbContext<ShopDbContext>(option =>
		{
			option.UseSqlServer(connectionString.ShopDbContextConnection);
		});
		//services.Configure<SmtpConfig>(Configuration.GetSection("Smtp"));



		
        services.AddScoped<IProductServisec, ProductServisec>();
		services.AddScoped<IUnitOfWork, ShopDbContext>();
		return services;
	}
}