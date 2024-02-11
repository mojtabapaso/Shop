using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.Contracts;

namespace Shop.Services.EFServices;

public class GenericServices<TEntity> : IGenericServices<TEntity> where TEntity : BaseEntitiy, new()
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<TEntity> _entity;

    public GenericServices(IUnitOfWork uow)
    {
        this.uow = uow;
        _entity = uow.Set<TEntity>();
    }
    public void Add(TEntity entity)
        => _entity.Add(entity);

    public async Task AddAsync(TEntity entity)
       => await _entity.AddAsync(entity);
    public TEntity FindById(int id)
        => _entity.Find(id);

    public async Task<TEntity> FindByIdAsync(int id)
        => await _entity.FindAsync(id);

    public List<TEntity> GetAll()
        => _entity.ToList();

    public async Task<List<TEntity>> GetAllAsync()
        => await _entity.ToListAsync();

    public void Remove(TEntity entity)
        => _entity.Remove(entity);

    public void Remove(string Id)
    {
        // var tEntity = new TEntity() { Id = Id };
        
        var tEntity = new TEntity();
        var idProperty = typeof(TEntity).GetProperty("Id");
        if (idProperty != null)
        {
            idProperty.SetValue(tEntity, Id, null); 
        }

        uow.MarkAsDeleted(tEntity);

    }
    public void Update(TEntity entity)
        => _entity.Update(entity);



}
