using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using POne.Admin.Api.Swagger;
using POne.Api.Extensions;
using POne.Core.Auth;
using POne.Identity.Business.CommandHandlers;
using POne.Identity.Business.Commands.Validators.Users;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Infra.Connections;
using POne.Identity.Infra.Repositories;
using POne.Infra.UnityOfWork;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;

var connectionString = configuration
    .GetConnectionString("POneAdmin") ?? string.Empty;

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
     .Get<string[]>() ?? Array.Empty<string>();


services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins(allowedCorsOrigns)));

var identityServerProtectedApiConfig = configuration
    .GetSection("IdentityServer")
    .Get<IdentityServerProtectedApiConfig>();

services.AddControllersWithViews()
    .AddJsonOptions((options) => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = identityServerProtectedApiConfig.Issuer;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = identityServerProtectedApiConfig.ValidateAudience,
            ValidateIssuer = identityServerProtectedApiConfig.ValidateIssuer
        };

        options.AddQueryStringAccessToken();
    });



services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "POne.Admin.Api",
        Version = "v1"
    });

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"{identityServerProtectedApiConfig.Issuer}/connect/authorize"),
                TokenUrl = new Uri($"{identityServerProtectedApiConfig.Issuer}/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    { "poneadminapi", "POne Admin Api Full Access" }
                },
            }
        },
    });

    c.OperationFilter<AuthorizeCheckOperationFilter>();
});


services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IProfileRepository, ProfileRepository>();
services.AddScoped<IRoleRepository, RoleRepository>();
services.AddScoped<IAccountRepository, AccountRepository>();
services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSignalR();

var app = builder.Build();

var env = app.Environment;

if (env.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.OAuthClientId("POne.Admin.Api.Swagger");
    c.OAuthScopes("poneadminapi");
});

app.UseCors("DefaultCors");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

using (var scope = app.Services.CreateScope())
{
    using var context = scope
        .ServiceProvider
        .GetRequiredService<POneIdentityDbContext>();

    await context.Database.MigrateAsync();
}

app.Run();


