using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.DataLayer.SeedData;

public class AdminConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		var admin = new User
		{
			Id = "1",
			UserName = "masteradmin",
			NormalizedUserName = "MASTERADMIN",

			Email = "Admin@Admin.com",
			NormalizedEmail = "ADMIN@ADMIN.COM",
			PhoneNumber = "09111111111",
			EmailConfirmed = true,
			PhoneNumberConfirmed = true,
			SecurityStamp = Guid.NewGuid().ToString(),
			//Password = "Password"
		};

		admin.PasswordHash = PassGenerate(admin);
		builder.HasData(admin);
	}

	public string PassGenerate(User user)
	{
		var passHash = new PasswordHasher<User>();
		return passHash.HashPassword(user, "password");
	}
}
