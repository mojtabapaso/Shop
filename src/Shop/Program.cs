using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.IocConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var Services = builder.Services;
//Services.AddCustomeServies();
Services.AddControllersWithViews();
//public IConfiguration configuration {  get; }
builder.Services.AddDbContext<ShopDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDbContextConnection"));
});
//Services.Configure<SmtpConfig>(IConfigurationSection("Smtp"));
//Services.Configure<SmtpConfig>(builder.Configuration.GetConnectionString("sdf"));
//IServiceCollection 


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
