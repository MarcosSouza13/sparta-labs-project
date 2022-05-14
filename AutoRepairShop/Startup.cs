using AutoRepairShop.Api.Services;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Api.Settings;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace AutoRepairShop.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Get secret key token
            //Authentication.Auth.key = Configuration.GetSection("Jwt")["Key"];

            // Db Connection
            services.AddDbContext<DataContext.DataContext>(options => options.UseSqlServer(Configuration.GetSection("Sql")["ConnectionString"]));

            services.AddScoped<HttpClient>();

            //Services
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IRepairShopService, RepairShopService>();
            services.AddScoped<IUserService, UserService>();

            //Repositories
            //services.AddScoped<IProductDapperRepository, ProductDapperRepository>();

            services.AddScoped(provider =>
            {
                return new SqlSettings()
                {
                    ConnectionString = Configuration.GetSection("Sql")["ConnectionString"]
                };
            });

            var loggerConfiguration = new LoggerConfiguration();

            Log.Logger = loggerConfiguration.CreateLogger();

            services.AddSingleton(Log.Logger);

            CorsPolicyBuilder corsPolicyBuilder = new CorsPolicyBuilder().AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();

            var enableCors = Environment.GetEnvironmentVariable("EnableCors");

            if ((enableCors != null && bool.Parse(enableCors)) || _env.EnvironmentName.ToLower() == "local")
            {
                corsPolicyBuilder = corsPolicyBuilder.SetIsOriginAllowed(origin => true);
            }

            services.AddCors(options => options.AddPolicy("CorsPolicy", corsPolicyBuilder.Build()));

            services.AddRouting(options => options.LowercaseUrls = true);

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.EnvironmentName == "Development")
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRouting();
            app.UseCors("CorsPolicy");
        }
    }

}
