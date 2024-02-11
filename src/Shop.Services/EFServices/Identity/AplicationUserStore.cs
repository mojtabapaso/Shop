using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;

namespace Shop.Services.EFServices.Identity;

public class AplicationUserStore:UserStore<User, Role, ShopDbContext,int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
{
	public AplicationUserStore(IUnitOfWork uow ,IdentityErrorDescriber identityErrorDescriber=null):base((ShopDbContext)uow, identityErrorDescriber)
	{

	}
}
