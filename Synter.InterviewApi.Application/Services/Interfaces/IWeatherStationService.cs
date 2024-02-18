using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;

namespace Synter.InterviewApi.Application.Services.Interfaces;

public interface IWeatherStationService
{
    WeatherStation AddWeatherStaion(WeatherStationRequestModel weatherStation);
}