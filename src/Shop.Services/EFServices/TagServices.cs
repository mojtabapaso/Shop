using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;

namespace Shop.Services.EFServices;

public class TagServices : GenericServices<Tag>, ITagServisec
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<Tag> tag;
    public TagServices(IUnitOfWork uow) : base(uow)
    {
        this.uow = uow;
        tag = uow.Set<Tag>();
    }
}
