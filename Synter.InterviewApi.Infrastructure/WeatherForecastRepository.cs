using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

namespace Synter.InterviewApi.Infrastructure
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApiDbContext _dbContext;

        public WeatherForecastRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(WeatherForecast weatherForecast)
        {
            _dbContext.WeatherForecast.Add(weatherForecast);
            _dbContext.SaveChanges();
        }
    }
}
