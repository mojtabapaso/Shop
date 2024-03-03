using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.DataLayer.SeedData;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		var role = new Role
		{
			Id = "1",
			Name = "Admin",
			ConcurrencyStamp = "b35494cf-4040-47e3-a6de-dee4b6f8e250",
			NormalizedName = "ADMIN",
		};
		builder.HasData(role);
	}
}
