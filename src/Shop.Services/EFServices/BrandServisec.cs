using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;

namespace Shop.Services.EFServices;

public class BrandServisec : GenericServices<Brand>, IBrandServisec
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<Brand> brands;
    public BrandServisec(IUnitOfWork uow) : base(uow)
    {
        this.uow = uow;
        brands = uow.Set<Brand>();
    }

}
