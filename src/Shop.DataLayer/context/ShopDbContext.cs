using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.DataLayer.SeedData;
using Shop.Entities;

namespace Shop.DataLayer.context;

public class ShopDbContext : IdentityDbContext<User,Role,string>, IUnitOfWork
{
	public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Tag> Tags { get; set; }
	public DbSet<Brand> Brands { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<ItemCart> ItemCarts { get; set; }
	public DbSet<Address> Addresses { get; set; }

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
