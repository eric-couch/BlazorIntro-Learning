using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using BlazorIntro.Server.Models;
using System.Security.Claims;

namespace BlazorIntro.Server.Factory;

public class CustomClaimsFactory : UserClaimsPrincipalFactory<ApplicationUser>
{
    public CustomClaimsFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("firstname", user.FirstName));
        identity.AddClaim(new Claim("lastname", user.LastName));
        return identity;
    }
}
