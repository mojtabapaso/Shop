using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;

namespace Shop.Services.EFServices;

public class OrderServisec : GenericServices<Order>, IOrderServisec
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<Order> order;
    public OrderServisec(IUnitOfWork uow) : base(uow)
    {
        this.uow = uow;
        order = uow.Set<Order>();
    }
}