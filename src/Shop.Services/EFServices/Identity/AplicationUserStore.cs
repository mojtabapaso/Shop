using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.DataLayer.context;
using Shop.Entities;

namespace Shop.Services.EFServices.Identity;

public class AplicationUserStore : UserStore<User, Role, ShopDbContext, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>
{
    public AplicationUserStore(IUnitOfWork uow, IdentityErrorDescriber identityErrorDescriber = null) : base((ShopDbContext)uow, identityErrorDescriber)
    {

    }
}
