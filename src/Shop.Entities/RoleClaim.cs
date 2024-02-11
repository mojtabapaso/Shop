using Microsoft.AspNetCore.Identity;

namespace Shop.Entities;

public  class RoleClaim:IdentityRoleClaim<int>
{
    public virtual Role Role { get; set; }
}
