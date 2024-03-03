using Shop.Entities;
using Shop.services.Contracts;

namespace Shop.Services.EntityContracts;

public interface IAddressServisec : IGenericServices<Address>
{
	public Task<List<Address>> GetAllAddressByIdUser(string userId);
}

