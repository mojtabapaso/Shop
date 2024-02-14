using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.DataLayer.SeedData;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<string>>
{
	public void Configure(EntityTypeBuilder<IdentityRole<string>> builder)
	{
		var role = new IdentityRole<string>
		{
			Id = "1",
			Name = "Admin",
			ConcurrencyStamp = "b35494cf-4040-47e3-a6de-dee4b6f8e250",
			NormalizedName = "ADMIN",
		};
		builder.HasData(role);
	}
}
