using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using POne.Api.Extensions;
using POne.Core.Auth;
using POne.Financial.Business.CommandHandlers;
using POne.Financial.Domain.Commands.Validators.Categories;
using POne.Financial.Domain.Contracts;
using POne.Financial.Infra.Connections;
using POne.Financial.Infra.Repositories;
using POne.Infra.UnityOfWork;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POne.Financial.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("POneFinancial");
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

            var allowedCorsOrigns = _configuration
                 .GetSection("AllowedCorsOrigins")
                 .Get<string[]>();

            services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins(allowedCorsOrigns)));

            var identityServerProtectedApiConfig = _configuration
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
                                { "ponefinancialapi", "POne Financial Api full access" },
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
            services.AddScoped<IBalanceRepository, BalanceRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "POne.Identity.Api v1");
                    c.OAuthClientId("POne.Financial.Api.Swagger");
                    c.OAuthScopes("ponefinancialapi");
                });
            }
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
        }
    }

    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                               context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

                operation.Security = new List<OpenApiSecurityRequirement>()
                {
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "oauth2"
                                }
                            },
                            new List<string>() { "ponefinancialapi" }
                        }
                    }
                };
            }
        }
    }
}
