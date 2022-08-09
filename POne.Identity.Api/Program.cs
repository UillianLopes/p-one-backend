using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POne.Api.Extensions;
using POne.Identity.Api;
using POne.Identity.Api.Identity;
using POne.Identity.Business.CommandHandlers;
using POne.Identity.Business.Commands.Validators.Users;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Infra.Connections;
using POne.Identity.Infra.Repositories;
using POne.Infra.UnityOfWork;
using System;
using System.Linq;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
configuration.AddEnvironmentVariables();

var services = builder.Services;

var connectionString = configuration
    .GetConnectionString("POneIdentity");

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


var allowedCorsOrigns = configuration
     .GetSection("AllowedCorsOrigins")
     .Get<string[]>();

services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins(allowedCorsOrigns)));

var identityServerConfig = configuration
    .GetSection("IdentityServer")
    .Get<IdentityServerConfig>();

services.AddIdentityServer(ops =>
{
    ops.IssuerUri = identityServerConfig.Issuer;
    ops.Authentication.CookieLifetime = TimeSpan.FromDays(2);
})
.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
.AddInMemoryClients(identityServerConfig.GetClients())
.AddInMemoryApiScopes(identityServerConfig.GetApiScopes())
.AddInMemoryIdentityResources(identityServerConfig.GetIdentityResources())
.AddInMemoryApiResources(identityServerConfig.GetApiResources())
.AddDeveloperSigningCredential()
.AddProfileService<ProfileService>()
.AddRedirectUriValidator<CustomRedirectUriValidator>();

services.AddControllersWithViews()
    .AddJsonOptions((options) => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull); ;

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IProfileRepository, ProfileRepository>();
services.AddScoped<IRoleRepository, RoleRepository>();
services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();
var env = app.Environment;

if (env.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseCors("DefaultCors");
app.UseStaticFiles();
if (!env.IsDocker())
    app.UseHttpsRedirection();

app.UseRouting();
app.UseIdentityServer();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

using (var scope = app.Services.CreateScope())
{
    using var context = scope
    .ServiceProvider
    .GetRequiredService<POneIdentityDbContext>();

    context.Database.Migrate();
}

app.Run();