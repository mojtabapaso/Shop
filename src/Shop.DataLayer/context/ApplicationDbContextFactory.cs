using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Shop.DataLayer.context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
{

	public ApplicationDbContextFactory()
	{
	}
	public ShopDbContext CreateDbContext(string[] args)
	{
		IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
		IConfigurationRoot root = builder.Build();
		string? sqlConnectionString = root["ConnectionStrings:DatabaseSQL:ShopDbContextConnection"];
		var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
        optionsBuilder.UseSqlite(sqlConnectionString);
        return new ShopDbContext(optionsBuilder.Options);
	}
}