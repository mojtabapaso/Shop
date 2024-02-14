using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.DataLayer.SeedData;
using Shop.Entities;
using Microsoft.AspNetCore.Identity;

namespace Shop.DataLayer.context;

public class ShopDbContext : IdentityDbContext<User,IdentityRole<string>,string>, IUnitOfWork
{
	public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Tag> Tags { get; set; }

	public void MarkAsDeleted<TEntity>(TEntity entity)
	{
		if (entity != null)
		{
			base.Entry(entity).State = EntityState.Deleted;
		}
	}

	public int SaveChange()
	{
		return base.SaveChanges();
	}

	public Task<int> SaveChangesAsync()
	{
		return base.SaveChangesAsync();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfiguration(new AdminConfiguration());

		modelBuilder.ApplyConfiguration(new RoleConfiguration());

		modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
	}
}
