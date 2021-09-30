using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POne.Api.Extensions;
using POne.App.Infra.Connections;
using POne.Infra.UnityOfWork;

namespace POne.App.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("POneApp");
            services.AddDbContext<POneAppDbContext>(opts => opts
                .UseSqlServer(connectionString)
                    .UseLazyLoadingProxies(),
                    ServiceLifetime.Scoped
                );

            services.AddPOneApi(builder => builder
                .WithUow<Uow<POneAppDbContext>>()
                //.WithValidatorsFromAssemblyOf<CreateUserCommandValidator>()
                //.WithCQRSFromAssemblyOf<UserCommandHandler>()
            );

            services.AddCors(cors => cors.AddPolicy("DefaultCors", config => config
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200")));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "POne.App.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "POne.App.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
