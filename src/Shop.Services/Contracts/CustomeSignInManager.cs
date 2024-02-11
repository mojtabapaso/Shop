using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shop.Entities;

//namespace Shop.Services.Contracts;

//public class CustomeSignInManager : SignInManager<User>
//{
//    private readonly UserManager<User> userManager;

//    public CustomeSignInManager(
//        UserManager<User> userManager,   
//        IHttpContextAccessor contextAccessor,
//        IUserClaimsPrincipalFactory<User> claimsFactory,
//        IOptions<IdentityOptions> optionsAccessor,
//        ILogger<SignInManager<User>> logger,
//        IAuthenticationSchemeProvider schemes
//        )
//        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
//    {
//        this.userManager = userManager; 
//    }

//    public async Task<User> FindByPhoneNumberAsync(string phoneNumber)
//    {
//        return await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
//    }
//}

