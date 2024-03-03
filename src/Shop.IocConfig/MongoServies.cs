using Microsoft.Extensions.DependencyInjection;
using Shop.DataLayer.context;
using Shop.Services.Contracts.MongoContracts;
using Shop.services.MongoServices;
using Shop.Services.MongoServices;
using Shop.Services.MongoContracts;

namespace Shop.IocConfig;

public static class MongoServies
{
	public static IServiceCollection AddMongoServies(this IServiceCollection services)
	{
		services.AddSingleton<IGetMongoCollection, GetMongoCollection>();
		services.AddSingleton<IMongoDbAuthenticationServices, MongoDbAuthenticationServices>();
		services.AddSingleton<IMongoCartServices, MongoCartServices>();
		services.AddSingleton<IMongoCouponServices, MongoCouponServices>();
		return services;
	}
}
