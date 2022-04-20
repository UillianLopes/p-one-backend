using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using POne.Api.Extensions;
using POne.Core.Auth;
using POne.Core.Options;
using POne.Financial.Api.Facades;
using POne.Financial.Api.Swagger;
using POne.Financial.Business.CommandHandlers;
using POne.Financial.Domain.Commands.Validators.Categories;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Contracts.Facades;
using POne.Financial.Infra.Connections;
using POne.Financial.Infra.Repositories;
using POne.Infra.UnityOfWork;
using System;
using System.Collections.Generic;

var builder = WebApplication
    .CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;

var connectionString = configuration
    .GetConnectionString("POneFinancial");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"CONNECTION STRING -> {connectionString}");
Console.ForegroundColor = ConsoleColor.White;

services.AddDbContext<POneFinancialDbContext>(opts => opts
    .UseSqlServer(connectionString)
        .UseLazyLoadingProxies(),
        ServiceLifetime.Scoped
    );

services.AddPOneApi(builder => builder
    .WithUow<Uow<POneFinancialDbContext>>()
    .WithValidatorsFromAssemblyOf<CreateCategoryCommandValidator>()
    .WithCQRSFromAssemblyOf<CategoryCommandHandler>()
);

var allowedCorsOrigns = configuration
     .GetSection("AllowedCorsOrigins")
     .Get<string[]>();

services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins(allowedCorsOrigns)
    .SetIsOriginAllowed((orign) =>
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ORIGIN -> {orign}");
        Console.ForegroundColor = ConsoleColor.White;
        return true;
    })));

var identityServerProtectedApiConfig = configuration
    .GetSection("IdentityServer")
    .Get<IdentityServerProtectedApiConfig>();

services.AddControllersWithViews();
services.AddAuthentication("token")
    .AddJwtBearer("token", options =>
    {
        options.Authority = identityServerProtectedApiConfig.IssuerUri;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = identityServerProtectedApiConfig.ValidateAudience,
        };
    });

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "POne.Identity.Api",
        Version = "v1"
    });

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                TokenUrl = new Uri("https://localhost:5001/connect/token"),
                Scopes = new Dictionary<string, string>
                            {
                                { "ponefinancialapi", "POne Financial Api Full Access" }
                            },
            }
        }
    });

    c.OperationFilter<AuthorizeCheckOperationFilter>();
});


services.AddScoped<IBankRepository, BankRepository>();
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
services.AddScoped<IEntryRepository, EntryRepository>();
services.AddScoped<IPaymentRepository, PaymentRepository>();
services.AddScoped<IWalletRepository, WalletRepository>();
services.AddScoped<IDashboardRepository, DashboardRepository>();
services.AddScoped<INotifierApiFacade, NotifierApiFacade>();
services.AddSingleton<IdentityApiFacade>();

services.AddSignalR();

var endpointsSection = configuration
    .GetSection("ApiEndpoints");

var endpoints = endpointsSection.Get<ApiEndpointOptions>();

services.Configure<ApiEndpointOptions>(endpointsSection);

services.AddHttpClient("POne.Notifier.Api.Client", (opts) =>
{
    opts.BaseAddress = new Uri(endpoints.NotifierApiEndpoint);
});

services.AddHttpClient("POne.Identity.Api.Client", (opts) =>
{
    opts.BaseAddress = new Uri(endpoints.IdentityApiEndpoint);
});

var app = builder.Build();
var env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "POne.Identity.Api v1");
    options.OAuthClientId("POne.Financial.Api.Swagger");
    options.OAuthScopes("ponefinancialapi");
});

app.UseCors("DefaultCors");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (Environment.GetEnvironmentVariables().Contains("MIGRATE"))
{
    using var scope = app.Services.CreateScope();

    using var context = scope
        .ServiceProvider
        .GetRequiredService<POneFinancialDbContext>();

    context.Database.Migrate();
}

app.Run();