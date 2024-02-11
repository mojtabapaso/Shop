using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shop.Entities;

public class UserClaim: IdentityUserClaim<int>
{
    public virtual User User { get; set; }
}
