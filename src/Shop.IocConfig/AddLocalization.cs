using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.IocConfig;

public static class AddLocalizationSerivesExtention
{
	public static IServiceCollection AddLocalizationSerives(this IServiceCollection services)
	{
		services.AddControllersWithViews()
		.AddViewLocalization()
		.AddDataAnnotationsLocalization();

		services.AddLocalization(options => options.ResourcesPath = "Resources");
		services.Configure<RequestLocalizationOptions>(options =>
		{
			options.DefaultRequestCulture = new RequestCulture("fa");
			const string defaultCulture = "fa";
			var supportedCultures = new[]
			{
			new CultureInfo(defaultCulture),
			new CultureInfo("en")
			};
			options.DefaultRequestCulture = new RequestCulture(defaultCulture);
			options.SupportedCultures = supportedCultures;
			options.SupportedUICultures = supportedCultures;
			options.SetDefaultCulture(defaultCulture);
			options.ApplyCurrentCultureToResponseHeaders = true;
			options.Equals(options.DefaultRequestCulture);
		});
		return services;
	}
}
