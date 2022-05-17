using AutoRepairShop.Api.DataContext;
using AutoRepairShop.Api.Repositories;
using AutoRepairShop.Api.Repositories.Dapper;
using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Api.Services;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt")["Key"]);

builder.Services
    .AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwtBearerOption =>
    {
        jwtBearerOption.RequireHttpsMetadata = false;
        jwtBearerOption.SaveToken = true;
        jwtBearerOption.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetSection("Sql")["ConnectionString"]).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddOptions();

//Repositories
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
builder.Services.AddScoped<IRepairShopRepository, RepairShopRepository>();
builder.Services.AddScoped<IRepairShopConfigurationRepository, RepairShopConfigurationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

//Services
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
builder.Services.AddScoped<IRepairShopService, RepairShopService>();
builder.Services.AddScoped<IRepairShopConfigurationService, RepairShopConfigurationService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton(provider =>
{
    var configFile = builder.Configuration.GetSection("Sql");
    return new SqlSettings()
    {
        ConnectionString = builder.Configuration.GetSection("Sql")["ConnectionString"]
    };
});

builder.Services.AddSingleton(provider =>
{
    var configFile = builder.Configuration.GetSection("Jwt");
    return new TokenSettings()
    {
        Token = builder.Configuration.GetSection("Jwt")["Key"]
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

// If using IIS:
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();