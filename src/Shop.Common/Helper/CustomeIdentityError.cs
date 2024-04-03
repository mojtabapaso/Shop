using Microsoft.AspNetCore.Identity;

namespace Shop.Helper;

public class CustomeIdentityError:IdentityErrorDescriber
{
    public override IdentityError ConcurrencyFailure()
    {
        return new IdentityError
        {
            Code = nameof(ConcurrencyFailure),
            Description = "خطای ناشناخته"
        };
    }
    public override IdentityError DuplicateEmail(string email)
    {
        return new IdentityError {
        Code = nameof(DuplicateEmail),
        Description = $"ایمیل تکراری است : {email}"
        };
    }

}
