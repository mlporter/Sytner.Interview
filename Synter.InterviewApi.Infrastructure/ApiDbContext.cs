using Microsoft.EntityFrameworkCore;
using Synter.InterviewApi.Domain.DataModels;

namespace Synter.InterviewApi.Infrastructure
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherStation> WeatherStation { get; set; }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        public DbSet<WeatherForecastDetailed> WeatherForecastDetailed { get; set; }
    }
}