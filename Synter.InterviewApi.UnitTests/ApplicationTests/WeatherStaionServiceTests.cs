using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Synter.InterviewApi.Application.Services;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Domain.ResponseModels;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;
using Sytner.InterviewApi.Controllers;


namespace Synter.InterviewApi.UnitTests.ApplicationTests
{
    public class WeatherStaionServiceTests
    {
        private const string stationName = "Corby";
        private const int stationId = 1;
        private const string stationCode = "WS001";
        private const decimal lat = (decimal)-0.5;
        private const decimal lon = (decimal)-0.5;


        [Fact]
        public void AddWeatherStation_ReturnsResult()
        {
            // Arrange
            WeatherStationRequestModel requestModel = new()
            {
                StationName = stationName,
                StationCode = stationCode,
                Latitude = lat,
                Longitude = lon
            };

            WeatherStation dbWeatherStation = new()
            {
                Name = stationName,
                Code = stationCode,
                Latitude = lat,
                Longitude = lon,
                Id = stationId,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            var weatherStationRepoMock = new Mock<IWeatherStationRepository>();
            weatherStationRepoMock.Setup(s => s.Add(dbWeatherStation));
            var weatherStationService = new WeatherStationService(weatherStationRepoMock.Object);

            // Act
            var result = weatherStationService.AddWeatherStation(requestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Name, stationName);
            Assert.Equal(result.Latitude, lat);
            Assert.Equal(result.Longitude, lon);
            Assert.Equal(DateTime.UtcNow.Day, result.CreatedDate.Day);
            Assert.Equal(DateTime.UtcNow.Day, result.ModifiedDate.Day);
        }

    }
}
