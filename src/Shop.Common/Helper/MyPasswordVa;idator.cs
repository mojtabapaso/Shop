using Microsoft.AspNetCore.Identity;
using Shop.Entities;

namespace Shop.Common.Helper;

public class MyPasswordValidator : IPasswordValidator<User>
{
    List<string> CommonPassword = new List<string>()
    {
        "123456","654321",
    };
    public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
    {
        if (CommonPassword.Contains(password))
        {
            var result =  IdentityResult.Failed(new IdentityError { 
            Code = "CommonPassword",
            Description = "Password is very simple",
            });
            return Task.FromResult(result);
        }
        return Task.FromResult(IdentityResult.Success);
        throw new NotImplementedException();
    }
}
