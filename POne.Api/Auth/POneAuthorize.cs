using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace POne.Api.Auth
{
    public class POneAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string Role { get; private set; }

        public POneAuthorizeAttribute(string role)
        {
            Role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null || context.HttpContext == null || context.HttpContext.User == null)
                return;

            if (context.HttpContext.User.Claims.Any((claim) => claim.Type == ClaimTypes.Role && claim.Value == "STANDALONE"))
                return;

            if (!context.HttpContext.User.Claims.Any((claim) => claim.Type == ClaimTypes.Role && claim.Value == Role))
                context.Result = new ForbidResult();
        }
    }
}
