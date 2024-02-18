using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Domain.ResponseModels;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

namespace Synter.InterviewApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        private readonly IWeatherStationService _weatherStationService;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository, IWeatherStationService weatherStationService)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _weatherStationService = weatherStationService;
        }

        public WeatherForecastResponseModel AddWeatherForecast(WeatherForecastRequestModel weatherForecast)
        {
            WeatherForecast dbWeatherForecast = new()
            {
                ForecastDate = weatherForecast.ForecastDate,
                WeatherStationId = weatherForecast.WeatherStationId,
                TemperatureC = weatherForecast.TemperatureC
            };
            _weatherForecastRepository.Add(dbWeatherForecast);

            WeatherForecastResponseModel mappedResponse = new()
            {
                Date = dbWeatherForecast.ForecastDate,
                TemperatureC = dbWeatherForecast.TemperatureC,
                WeatherStationId = dbWeatherForecast.WeatherStationId,
                WeatherStationName = _weatherStationService.GetWeatherStation(dbWeatherForecast.WeatherStationId).Name
            };

            return mappedResponse;
        }

        public IEnumerable<WeatherForecastResponseModel> SearchForecastsByStationId(
            WeatherForecastByStationIdRequestModel request)
        {
            var forecasts =
                _weatherForecastRepository.SearchForecastsByStationId(request.StationId, request.DateFrom,
                    request.DateTo);

            return forecasts.Select(forecast => new WeatherForecastResponseModel()
            {
                WeatherStationId = forecast.WeatherStationId,
                WeatherStationName = forecast.WeatherStationName,
                TemperatureC = forecast.TemperatureC,
                Date = forecast.ForecastDate
            }).ToList();
        }

        public WeatherForecastResponseModel UpdateWeatherForecast(WeatherForecastUpdateRequestModel forecast)
        {
            WeatherForecast dbWeatherForecast = new()
            {
                Id = forecast.Id,
                ForecastDate = forecast.ForecastDate,
                WeatherStationId = forecast.WeatherStationId,
                TemperatureC = forecast.TemperatureC,
                ModifiedDate = DateTime.UtcNow
            };

            _weatherForecastRepository.Update(dbWeatherForecast);

            WeatherForecastResponseModel mappedResponse = new()
            {
                Date = dbWeatherForecast.ForecastDate,
                TemperatureC = dbWeatherForecast.TemperatureC,
                WeatherStationId = dbWeatherForecast.WeatherStationId,
                WeatherStationName = _weatherStationService.GetWeatherStation(dbWeatherForecast.WeatherStationId).Name
            };

            return mappedResponse;
        }
    }
}
