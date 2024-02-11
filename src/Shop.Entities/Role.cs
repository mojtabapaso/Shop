using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shop.Entities;

public class Role:IdentityRole<int>
{
	public virtual ICollection<RoleClaim> RoleClaims { get; set; }	
	public virtual ICollection<UserRole> UserRoles { get; set; }	

}
