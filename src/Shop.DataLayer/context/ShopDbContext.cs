using Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shop.DataLayer.context;

public  class ShopDbContext :IdentityDbContext<User,Role,int>, IUnitOfWork
{
	public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options){ }

	//public DbSet<User> Users { get; set; }
	public DbSet<Product> Products { get; set; }

	public int SaveChange()
	{
		throw new NotImplementedException();
	}

	public Task<int> SaveChangesAsync()
	{
		return base.SaveChangesAsync(); 
	}
}

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
{
	public ShopDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
		optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");
		//builder.Configuration.GetConnectionString("ShopDbContextConnection")

		return new ShopDbContext(optionsBuilder.Options);
	}
}