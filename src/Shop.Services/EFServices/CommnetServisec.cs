using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;

namespace Shop.Services.EFServices;

public class CommnetServisec : GenericServices<Comment>, ICommnetServisec
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<Comment> comments;
    public CommnetServisec(IUnitOfWork uow) : base(uow)
    {
        this.uow = uow;
        comments = uow.Set<Comment>();
    }
}
