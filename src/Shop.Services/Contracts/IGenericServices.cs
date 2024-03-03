using Shop.Entities;

namespace Shop.services.Contracts;

public interface IGenericServices<TEntity> where TEntity : BaseEntitiy
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void Remove(string Id);
    TEntity FindById(string id); 
    Task<TEntity> FindByIdAsync(string id); 
    List<TEntity> GetAll();
    Task<List<TEntity>> GetAllAsync();
}
