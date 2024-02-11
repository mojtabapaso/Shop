using Microsoft.AspNetCore.Identity;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.IocConfig;
using Shop.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var Services = builder.Services;
Services.AddCustomeServies();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseSession();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
