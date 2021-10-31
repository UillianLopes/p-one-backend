using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POne.Api.Extensions;
using POne.Financial.Business.CommandHandlers;
using POne.Financial.Business.Commands.Validators.Categories;
using POne.Financial.Infra.Connections;
using POne.Infra.UnityOfWork;

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

            services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200")));

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "POne.Identity.Api",
                    Version = "v1"
                });
            });


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
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
