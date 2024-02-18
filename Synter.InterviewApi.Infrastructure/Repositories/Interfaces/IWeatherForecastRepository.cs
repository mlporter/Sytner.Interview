using Synter.InterviewApi.Domain.DataModels;

namespace Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

public interface IWeatherForecastRepository
{
    void Add(WeatherForecast weatherForecast);

    IEnumerable<WeatherForecastDetailed> SearchForecastsByStationId(int stationId, DateTime dateFrom, DateTime dateTo);
}