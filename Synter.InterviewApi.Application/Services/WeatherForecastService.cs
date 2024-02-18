using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

namespace Synter.InterviewApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public WeatherForecast AddWeatherForecast(WeatherForecastRequestModel weatherForecast)
        {
            WeatherForecast dbWeatherForecast = new()
            {
                ForecastDate = weatherForecast.ForecastDate,
                WeatherStationId = weatherForecast.WeatherStationId,
                TemperatureC = weatherForecast.TemperatureC
            };
            _weatherForecastRepository.Add(dbWeatherForecast);
            return dbWeatherForecast;
        }
    }
}
