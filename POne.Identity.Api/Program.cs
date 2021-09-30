using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POne.Identity.Infra.Repositories;
using System;
using System.Linq;
using System.Reflection;

namespace POne.Identity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var seed = args.Contains("/seed");

                if (seed)
                {
                    args = args.Except(new[] { "/seed" }).ToArray();
                }

                var host = CreateHostBuilder(args).Build();

                if (seed)
                {
                    var config = host.Services.GetRequiredService<IConfiguration>();
                    var connectionString = config.GetConnectionString("POneIdentity");
                    var migrationsAssemblyName = typeof(UserRepository)
                        .GetTypeInfo()
                        .Assembly
                        .GetName()
                        .Name;

                    SeedData.EnsureSeedData(connectionString, migrationsAssemblyName);

                    return;
                }

                host.Run();
            }
            catch
            {
                return;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
