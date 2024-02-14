using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using Microsoft.AspNetCore.Identity;

namespace Shop.DataLayer.SeedData;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
	public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
	{
		builder.HasData(new IdentityUserRole<string>
		{
			RoleId = "1",
			UserId = "1",
		
		});

	}
}