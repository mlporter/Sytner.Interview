using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Domain.ResponseModels;

namespace Synter.InterviewApi.Application.Services.Interfaces;

public interface IWeatherForecastService
{
    WeatherForecastResponseModel AddWeatherForecast(WeatherForecastRequestModel weatherForecast);

    IEnumerable<WeatherForecastResponseModel>
        SearchForecastsByStationId(WeatherForecastByStationIdRequestModel request);
}