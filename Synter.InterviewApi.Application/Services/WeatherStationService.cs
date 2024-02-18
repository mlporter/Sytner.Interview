using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

namespace Synter.InterviewApi.Application.Services
{
    public class WeatherStationService : IWeatherStationService
    {
        private readonly IWeatherStationRepository _weatherStationRepository;

        public WeatherStationService(IWeatherStationRepository weatherStationRepository)
        {
            _weatherStationRepository = weatherStationRepository;
        }

        public WeatherStation AddWeatherStaion(WeatherStationRequestModel weatherStation)
        {
            WeatherStation dbWeatherStation = new()
            {
                Name = weatherStation.StationName,
                Code = weatherStation.StationCode,
                Latitude = weatherStation.Latitude,
                Longitude = weatherStation.Longitude
            };
            _weatherStationRepository.Add(dbWeatherStation);
            return dbWeatherStation;
        }
    }
}
