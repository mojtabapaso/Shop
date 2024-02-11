using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Shop.Entities;

public class UserLogin: IdentityUserLogin<int>
{
    public virtual User User { get; set; }
}
