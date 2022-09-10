using CartService.Data;
using CartService.Config;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MassTransit;
using System.Reflection;
using CartService.Repositories;
using CartService.Contracts;

namespace CartService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            //
            builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


            builder.Services.AddMassTransit(configure =>
            {
                configure.AddConsumers(Assembly.GetEntryAssembly());
                configure.UsingRabbitMq((context, configurator) =>
                {
                    var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
                    configurator.Host(rabbitMqSettings.Host);
                });
                builder.Services.AddMassTransitHostedService();

            }


            );

            //registering serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File("logs/errors.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            

            builder.Host.UseSerilog();

            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<IProductTwinRepository, ProductTwinRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();

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
        }
    }
}