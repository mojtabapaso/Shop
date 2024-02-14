using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shop.Entities;

public class User : IdentityUser<string>
{

	public DateTime CreateDateTime { get; set; }
	[MaxLength(50)]
	public string? FirstName { get; set; }= string.Empty;
	[MaxLength(50)]
	public string? LastName { get; set; } = string.Empty;
	[NotMapped]
	public string FullName => $"{FirstName} {LastName}";


}
