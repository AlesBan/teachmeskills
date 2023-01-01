using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AspAuth.Policies;

public static class NamePolicy
{
    public const string Policy = "ales-auth-policy";

    public static AuthorizationPolicy Requirements => new AuthorizationPolicy(new[]
    {
        new ClaimsAuthorizationRequirement(ClaimTypes.Name,
            new[] { "ales" })
    }, new[] { CookieAuthenticationDefaults.AuthenticationScheme });
}