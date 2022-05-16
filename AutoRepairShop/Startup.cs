using AutoRepairShop.Api.Repositories;
using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Api.Services;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Api.Settings;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace AutoRepairShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Get secret key token

            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            services.AddScoped<IRepairShopRepository, RepairShopRepository>();
            services.AddScoped<IRepairShopConfigurationRepository, RepairShopConfigurationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Services
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IRepairShopService, RepairShopService>();
            services.AddScoped<IRepairShopConfigurationService, RepairShopConfigurationService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton(provider =>
            {
                return new SqlSettings()
                {
                    ConnectionString = Configuration.GetSection("Sql")["ConnectionString"]
                };
            });


            services.AddSignalR();
            services.AddMvc();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddControllers();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //if (app.Environment.IsDevelopment())
            /// {
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //appBuilder.MapControllers();

            //app.Run();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
