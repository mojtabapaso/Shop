using Microsoft.Extensions.DependencyInjection;
using Shop.DataLayer.context;
using Shop.Services.EFServices;
using Shop.Services.EntityContracts;

namespace Shop.IocConfig;

public static class EntityServies
{
	public static IServiceCollection AddEntityServies(this IServiceCollection services)
	{
		//EntityServies
		services.AddScoped<IProductServisec, ProductServisec>();
		services.AddScoped<ICategoryServisec, CategoryServices>();
		services.AddScoped<ITagServisec, TagServices>();
		services.AddScoped<IBrandServisec, BrandServisec>();
		services.AddScoped<ICommnetServisec, CommnetServisec>();
		services.AddScoped<IAddressServisec, AddressServisec>();
		services.AddScoped<IOrderServisec, OrderServisec>();
		return services;
	}


}
