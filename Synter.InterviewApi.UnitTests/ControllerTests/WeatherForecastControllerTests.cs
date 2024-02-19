using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Domain.ResponseModels;
using Sytner.InterviewApi.Controllers;

namespace Synter.InterviewApi.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ReturnsCorrectData()
        {
            // Arrange
            var expectedData = new List<WeatherForecastResponseModel>
            {
                new() { Date = DateTime.UtcNow.AddDays(1) },
                new() { Date = DateTime.UtcNow.AddDays(2) },
                new() { Date = DateTime.UtcNow.AddDays(3) },
                new() { Date = DateTime.UtcNow.AddDays(4) },
                new() { Date = DateTime.UtcNow.AddDays(5) }
            };

            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var weatherForecastServiceMock = new Mock<IWeatherForecastService>();

            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            controllerContext.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

            var controller = new WeatherForecastController(loggerMock.Object, weatherForecastServiceMock.Object)
            {
                ControllerContext = controllerContext
            };

            // Act
            var result = controller.Get();
            var statusCode = ((JsonResult)result).StatusCode;
            var items = ((IEnumerable<WeatherForecastResponseModel>)((JsonResult)result).Value).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, statusCode);
            Assert.Equal(5, items.Count);

            for (var i = 0; i < expectedData.Count; i++)
            {
                Assert.Equal(expectedData[i].Date.Date, items[i].Date.Date);
                Assert.NotNull(items[i].Summary);
            }
        }

        [Fact]
        public void Add_ValidForecast_ReturnsAddedForecast()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var weatherForecastServiceMock = new Mock<IWeatherForecastService>();
            var stationName = "Corby";
            WeatherForecastResponseModel responseModel = new()
            {
                Date = DateTime.UtcNow.AddDays(2),
                WeatherStationId = 1,
                TemperatureC = 10,
                WeatherStationName = stationName
            };

            WeatherForecastRequestModel requestModel = new()
            {
                ForecastDate = DateTime.UtcNow.AddDays(2),
                WeatherStationId = 1,
                TemperatureC = 10
            };

            weatherForecastServiceMock.Setup(s => s.AddWeatherForecast(requestModel)).Returns(responseModel);

            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            controllerContext.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

            var controller = new WeatherForecastController(loggerMock.Object, weatherForecastServiceMock.Object)
            {
                ControllerContext = controllerContext
            };

            // Act
            var result = controller.Add(requestModel);
            var statusCode = ((JsonResult)result).StatusCode;
            var item = (WeatherForecastResponseModel)((JsonResult)result).Value;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, statusCode);
            Assert.Equal(responseModel.Date, item.Date);
            Assert.Equal(responseModel.WeatherStationId, item.WeatherStationId);
            Assert.Equal(responseModel.TemperatureC, item.TemperatureC);
            Assert.NotNull(item.Summary);
            Assert.Equal(responseModel.TemperatureF, item.TemperatureF);
            Assert.Equal(stationName, item.WeatherStationName);
        }
    }
}