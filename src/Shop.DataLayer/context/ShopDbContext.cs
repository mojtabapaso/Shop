using Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shop.DataLayer.context;

public class ShopDbContext :IdentityDbContext<User,Role,int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>, IUnitOfWork
{
	public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options){ }

	//public DbSet<User> Users { get; set; }
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
}
