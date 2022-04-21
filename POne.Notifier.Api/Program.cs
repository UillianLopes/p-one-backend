using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using POne.Api.Extensions;
using POne.Core.Auth;
using POne.Financial.Infra.Repositories;
using POne.Infra.UnityOfWork;
using POne.Notifier.Api.Facades;
using POne.Notifier.Api.Hubs;
using POne.Notifier.Api.Swagger;
using POne.Notifier.Business.CommandHandlers;
using POne.Notifier.Business.CommandValidators.Notification;
using POne.Notifier.Domain.Contracts.Facades;
using POne.Notifier.Domain.Contracts.Repositories;
using POne.Notifier.Infra.Connections;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;

var services = builder.Services;

var connectionString = configuration
    .GetConnectionString("POneNotifier");

services.AddDbContext<POneNotifierDbContext>(opts => opts
    .UseSqlServer(connectionString)
        .UseLazyLoadingProxies(),
        ServiceLifetime.Scoped
    );

services.AddPOneApi(builder => builder
    .WithUow<Uow<POneNotifierDbContext>>()
    .WithValidatorsFromAssemblyOf<CreateNotificationCommandValidator>()
    .WithCQRSFromAssemblyOf<NotificationCommandHandler>()
);

var allowedCorsOrigns = configuration
     .GetSection("AllowedCorsOrigins")
     .Get<string[]>();


services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins(allowedCorsOrigns)));

var identityServerProtectedApiConfig = configuration
    .GetSection("IdentityServer")
    .Get<IdentityServerProtectedApiConfig>();

services.AddControllersWithViews();
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
        Title = "POne.Notifier.Api",
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
                    { "ponenotifierapi", "POne Notifier Api Full Access" }
                },
            }
        },
    });

    c.OperationFilter<AuthorizeCheckOperationFilter>();
});

services.AddSingleton<NotificationsHub>();
services.AddScoped<INotificationRepository, NotificationRepository>();
services.AddScoped<INotificationsHubFacade, NotificationsHubFacade>();
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
    c.OAuthClientId("POne.Notifier.Api.Swagger");
    c.OAuthScopes("ponenotifierapi");
});

app.UseCors("DefaultCors");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationsHub>("/hubs/notifications")
        .RequireAuthorization();

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
        .GetRequiredService<POneNotifierDbContext>();

    await context.Database.MigrateAsync();
}

app.Run();


