using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace POne.Api.Extensions
{
    public static class JwtBearerOptionsExtensions
    {
        public static void AddQueryStringAccessToken(this JwtBearerOptions options)
        {
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = (context) =>
                {
                    if (!context.Request.Query.TryGetValue("access_token", out StringValues values))
                    {
                        return Task.CompletedTask;
                    }

                    if (values.Count > 1)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Fail(
                            "Only one 'access_token' query string parameter can be defined. " +
                            $"However, {values.Count:N0} were included in the request."
                        );

                        return Task.CompletedTask;
                    }

                    var token = values.Single();

                    if (String.IsNullOrWhiteSpace(token))
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Fail(
                            "The 'access_token' query string parameter was defined, " +
                            "but a value to represent the token was not included."
                        );

                        return Task.CompletedTask;
                    }

                    context.Token = token;

                    return Task.CompletedTask;
                }
            };
        }
    }
}
