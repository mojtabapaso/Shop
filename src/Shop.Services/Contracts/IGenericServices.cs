using Shop.Entities;

namespace Shop.services.Contracts;

public interface IGenericServices<TEntity> where TEntity : BaseEntitiy
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void Remove(string Id);
    TEntity FindById(int id); 
    Task<TEntity> FindByIdAsync(int id); 
    List<TEntity> GetAll();
    Task<List<TEntity>> GetAllAsync();
}
