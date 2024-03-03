using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.IocConfig;

public static class LocalizationSerives
{
	public static IServiceCollection AddLocalizationSerives(this IServiceCollection services)
	{
		services.AddLocalization(options => options.ResourcesPath = "Resources");
		services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
			.AddDataAnnotationsLocalization();
		services.Configure<RequestLocalizationOptions>(option =>
		{
			var support = new List<CultureInfo>()
			{
			new CultureInfo("fa-IR"),
			new CultureInfo("en-US")
			};
			option.DefaultRequestCulture = new RequestCulture("fa-IR");
			option.SupportedCultures = support;
			option.SupportedUICultures = support;
			option.ApplyCurrentCultureToResponseHeaders = true;
			option.RequestCultureProviders = new List<IRequestCultureProvider>()
			{
			new CookieRequestCultureProvider(),
			new QueryStringRequestCultureProvider(),
			};
		});
		return services;
	}
}
