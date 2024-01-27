using Microsoft.EntityFrameworkCore;

namespace Shop.DataLayer.context
{
	public  interface IUnitOfWork : IDisposable
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		int SaveChange();

		Task<int> SaveChangesAsync();
		 
	}
}
