using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shop.Entities;

namespace Shop.Services.EFServices.Identity;

public class CustomeUserManager : UserManager<User>
{
    public CustomeUserManager(IUserStore<User> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager<User>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }
    public async Task<User> FindByPhoneNumberAsync(string phoneNumber)
    {
        return await Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await Users.ToListAsync();

    }
}
