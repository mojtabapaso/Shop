using Shop.IocConfig;
using Microsoft.Extensions.Options;
using Shop;

var builder = WebApplication.CreateBuilder(args);

var Services = builder.Services;
Services.AddCustomeServies();
Services.AddLocalizationSerives();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseMiddleware<CultureMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
