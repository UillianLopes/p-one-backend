using Microsoft.AspNetCore.Hosting;

namespace POne.Api.Extensions
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsDocker(this IWebHostEnvironment environment) => environment.EnvironmentName == "Docker";
    }
}
