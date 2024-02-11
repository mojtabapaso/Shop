using Microsoft.AspNetCore.Identity;

namespace Shop.Entities;

public class UserToken:IdentityUserToken<int>
{
    public virtual User User { get; set; }

}
