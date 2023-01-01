using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace JWTAuth.Policies;

public static class NamePolicy
{
    public const string Policy = "ales-auth-policy";

    public static AuthorizationPolicy Requirements => new AuthorizationPolicy(new[]
    {
        new ClaimsAuthorizationRequirement(ClaimTypes.Name,
            new[] { "ales" })
    }, new[] { JwtBearerDefaults.AuthenticationScheme });
}