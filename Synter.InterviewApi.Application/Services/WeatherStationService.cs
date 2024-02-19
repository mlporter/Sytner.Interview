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

        public WeatherStation AddWeatherStation(WeatherStationRequestModel weatherStation)
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

        public WeatherStation? GetWeatherStation(int id)
        {
            return _weatherStationRepository.Get(id);
        }

        public WeatherStation Update(WeatherStationRequestModel weatherStation)
        {
            WeatherStation dbWeatherStation = new()
            {
                Name = weatherStation.StationName,
                Code = weatherStation.StationCode,
                Latitude = weatherStation.Latitude,
                Longitude = weatherStation.Longitude
            };
            _weatherStationRepository.Update(dbWeatherStation);
            return dbWeatherStation;
        }
    }
}
