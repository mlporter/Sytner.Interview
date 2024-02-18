using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Synter.InterviewApi.Application.Services;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Infrastructure;
using Synter.InterviewApi.Infrastructure.Repositories;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

namespace Sytner.InterviewApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add the database connection to the DB context.
            builder.Services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services and repositories
            builder.Services.AddScoped<IWeatherStationRepository, WeatherStationRepository>();
            builder.Services.AddScoped<IWeatherStationService, WeatherStationService>();

            builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}