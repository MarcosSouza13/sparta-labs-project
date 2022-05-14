//using AutoRepairShop.Api;
//using Microsoft.AspNetCore;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        //var host = WebHost.CreateDefaultBuilder()
//        //    .UseIISIntegration()
//        //    .UseContentRoot(Directory.GetCurrentDirectory())
//        //    .UseStartup<Startup>()
//        //    .Build();

//        //host.Run();
//    }
//}
using AutoRepairShop.Api.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetSection("Sql")["ConnectionString"]));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
