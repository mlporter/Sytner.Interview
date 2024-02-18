using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

namespace Synter.InterviewApi.Infrastructure.Repositories
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

        public IEnumerable<WeatherForecastDetailed> SearchForecastsByStationId(int stationId, DateTime dateFrom,
            DateTime dateTo)
        {
            return from forecast in _dbContext.WeatherForecast
                join station in _dbContext.WeatherStation on forecast.WeatherStationId equals station.Id
                where forecast.WeatherStationId == stationId &&
                      forecast.ForecastDate >= dateFrom &&
                      forecast.ForecastDate <= dateTo
                select new WeatherForecastDetailed()
                {
                    Id = forecast.Id,
                    ForecastDate = forecast.ForecastDate,
                    TemperatureC = forecast.TemperatureC,
                    WeatherStationId = station.Id,
                    WeatherStationName = station.Name
                };
        }

        public void Update(WeatherForecast weatherForecast)
        {
            _dbContext.WeatherForecast.Update(weatherForecast);
            _dbContext.SaveChanges();
        }
    }
}