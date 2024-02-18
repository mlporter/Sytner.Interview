using Synter.InterviewApi.Domain.DataModels;

namespace Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

public interface IWeatherStationRepository
{
    void Add(WeatherStation weatherStation);
}