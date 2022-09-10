using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductInventoryService.Config;
using ProductInventoryService.Contracts;
using ProductInventoryService.Data;
using ProductInventoryService.Repositories;

namespace ProductInventoryService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<DatabaseContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddMassTransit(x => x.UsingRabbitMq((context, configurator) =>
            {
                var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
                configurator.Host(rabbitMqSettings.Host);
            }));
            builder.Services.AddMassTransitHostedService();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

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