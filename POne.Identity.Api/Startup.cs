using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POne.Api.Extensions;
using POne.Identity.Api.Identity;
using POne.Identity.Business.CommandHandlers;
using POne.Identity.Business.Commands.Validators.Users;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Infra.Connections;
using POne.Identity.Infra.Repositories;
using POne.Infra.UnityOfWork;
using System;
using System.Reflection;

namespace POne.Identity.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("POneIdentity");
            services.AddDbContext<POneIdentityDbContext>(opts => opts
                .UseSqlServer(connectionString)
                    .UseLazyLoadingProxies(),
                    ServiceLifetime.Scoped
                );

            services.AddPOneApi(builder => builder
                .WithUow<Uow<POneIdentityDbContext>>()
                .WithValidatorsFromAssemblyOf<CreateUserCommandValidator>()
                .WithCQRSFromAssemblyOf<UserCommandHandler>()
            );

            var migrationsAssemblyName = typeof(UserRepository)
                .GetTypeInfo()
                .Assembly
                .GetName()
                .Name;

            services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200")));

            services.AddIdentityServer(ops =>
            {
                ops.IssuerUri = "https://localhost:5001";
                ops.Authentication.CookieLifetime = TimeSpan.FromHours(2);
            })
            .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
            .AddConfigurationStore(config =>
            {
                config.ConfigureDbContext = d => d.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssemblyName));
            })
            .AddOperationalStore(config =>
            {
                config.ConfigureDbContext = d => d.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssemblyName));
            })
            .AddDeveloperSigningCredential()
            .AddProfileService<ProfileService>();

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "POne.Identity.Api",
                    Version = "v1"
                });
            });


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "POne.Identity.Api v1"));
            }
            app.UseCors("DefaultCors");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
