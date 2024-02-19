using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;
using Sytner.InterviewApi.Controllers;

namespace Synter.InterviewApi.UnitTests.ControllerTests
{
    public class WeatherStationControllerTests
    {
        [Fact]
        public void AddValidWeatherStation_ReturnsAddedStation()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherStationController>>();
            var weatherStationServiceMock = new Mock<IWeatherStationService>();
            var stationName = "Kettering";
            var stationId = 3;
            var stationCode = "WS003";
            var lat = 50;
            var lon = 50;
            WeatherStation responseModel = new()
            {
                Name = stationName,
                Id = stationId,
                Code = stationCode,
                Latitude = lat,
                Longitude = lon,
                CreatedDate = DateTime.UtcNow.Date,
                ModifiedDate = DateTime.UtcNow.Date
            };

            WeatherStationRequestModel requestModel = new()
            {
                StationName = stationName,
                StationCode = stationCode,
                Latitude = lat,
                Longitude = lon,
            };
            weatherStationServiceMock.Setup(s => s.AddWeatherStation(requestModel)).Returns(responseModel);

            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            controllerContext.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

            var controller = new WeatherStationController(loggerMock.Object, weatherStationServiceMock.Object)
            {
                ControllerContext = controllerContext
            };

            // Act
            var result = controller.Add(requestModel);
            var statusCode = ((JsonResult)result).StatusCode;
            var item = (WeatherStation)((JsonResult)result).Value;

            // Assert
            Assert.Equal(200, statusCode);
            Assert.Equal(responseModel.CreatedDate, item.CreatedDate);
            Assert.Equal(responseModel.ModifiedDate, item.ModifiedDate);
            Assert.Equal(responseModel.Id, item.Id);
            Assert.Equal(responseModel.Code, item.Code);
            Assert.Equal(responseModel.Latitude, item.Latitude);
            Assert.Equal(responseModel.Longitude, item.Longitude);
        }

        [Fact]
        public void UpdateValidWeatherStation_ReturnsAddedStation()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherStationController>>();
            var weatherStationServiceMock = new Mock<IWeatherStationService>();
            var stationName = "Kettering South";
            var stationId = 3;
            var stationCode = "WS003B";
            var lat = 51;
            var lon = 52;
            WeatherStation responseModel = new()
            {
                Name = stationName,
                Id = stationId,
                Code = stationCode,
                Latitude = lat,
                Longitude = lon,
                CreatedDate = DateTime.UtcNow.Date,
                ModifiedDate = DateTime.UtcNow.Date
            };

            WeatherStationRequestModel requestModel = new()
            {
                StationName = stationName,
                StationCode = stationCode,
                Latitude = lat,
                Longitude = lon,
            };
            weatherStationServiceMock.Setup(s => s.Update(requestModel)).Returns(responseModel);

            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            controllerContext.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

            var controller = new WeatherStationController(loggerMock.Object, weatherStationServiceMock.Object)
            {
                ControllerContext = controllerContext
            };

            // Act
            var result = controller.Update(requestModel);
            var statusCode = ((JsonResult)result).StatusCode;
            var item = (WeatherStation)((JsonResult)result).Value;

            // Assert
            Assert.Equal(200, statusCode);
            Assert.Equal(responseModel.CreatedDate, item.CreatedDate);
            Assert.Equal(responseModel.ModifiedDate, item.ModifiedDate);
            Assert.Equal(responseModel.Id, item.Id);
            Assert.Equal(responseModel.Code, item.Code);
            Assert.Equal(responseModel.Latitude, item.Latitude);
            Assert.Equal(responseModel.Longitude, item.Longitude);
        }

        [Fact]
        public void GetValidWeatherStation_ReturnsStation()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherStationController>>();
            var weatherStationServiceMock = new Mock<IWeatherStationService>();
            var stationName = "Corby";
            var stationId = 1;
            var stationCode = "WS001";
            var lat = -4;
            var lon = -52;
            WeatherStation responseModel = new()
            {
                Name = stationName,
                Id = stationId,
                Code = stationCode,
                Latitude = lat,
                Longitude = lon,
                CreatedDate = DateTime.UtcNow.Date,
                ModifiedDate = DateTime.UtcNow.Date
            };

            weatherStationServiceMock.Setup(s => s.GetWeatherStation(stationId)).Returns(responseModel);

            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            controllerContext.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

            var controller = new WeatherStationController(loggerMock.Object, weatherStationServiceMock.Object)
            {
                ControllerContext = controllerContext
            };

            // Act
            var result = controller.Get(stationId);
            var statusCode = ((JsonResult)result).StatusCode;
            var item = (WeatherStation)((JsonResult)result).Value;

            // Assert
            Assert.Equal(200, statusCode);
            Assert.Equal(responseModel.CreatedDate, item.CreatedDate);
            Assert.Equal(responseModel.ModifiedDate, item.ModifiedDate);
            Assert.Equal(responseModel.Id, item.Id);
            Assert.Equal(responseModel.Code, item.Code);
            Assert.Equal(responseModel.Latitude, item.Latitude);
            Assert.Equal(responseModel.Longitude, item.Longitude);
        }
    }
}