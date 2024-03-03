using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.EntityContracts;

namespace Shop.Services.EFServices;

public class AddressServisec : GenericServices<Address>, IAddressServisec
{
    private readonly IUnitOfWork uow;
    private readonly DbSet<Address> address;
    public AddressServisec(IUnitOfWork uow) : base(uow)
    {
        this.uow = uow;
        address = uow.Set<Address>();
    }

	public async Task<List<Address>> GetAllAddressByIdUser(string userId)
	{
		var listAddress = await address.Where(a=>a.UserId == userId).ToListAsync();
        return listAddress;

	}
}
