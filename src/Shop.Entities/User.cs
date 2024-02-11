using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shop.Entities;

public class User : IdentityUser<int>
{

	public DateTime CreateDateTime { get; set; }
	[MaxLength(50)]
	public string? FirstName { get; set; }= string.Empty;
	[MaxLength(50)]
	public string? LastName { get; set; } = string.Empty;
	[NotMapped]
	public string FullName => $"{FirstName} {LastName}";

	public virtual ICollection<UserClaim>? UserClaims { get; set; }
	public virtual ICollection<UserLogin>? UserLogins { get; set; }
	public virtual ICollection<UserRole>? UserRoles { get; set; }
	public virtual ICollection<UserToken>? UserTokens { get; set; }

}
