using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Domain.ResponseModels;
using Sytner.InterviewApi.Controllers;

namespace Synter.InterviewApi.UnitTests.ControllerTests
{
    public class WeatherForecastSearchControllerTests
    {
        [Fact]
        public void GetForecastsByStationId_ReturnsCorrectData()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastSearchController>>();
            var weatherForecastServiceMock = new Mock<IWeatherForecastService>();

            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            controllerContext.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

            var controller = new WeatherForecastSearchController(loggerMock.Object, weatherForecastServiceMock.Object)
            {
                ControllerContext = controllerContext
            };

            var weatherStationId = 2;
            var weatherStationName = "Stratford";

            WeatherForecastByStationIdRequestModel requestModel = new()
            {
                DateFrom = DateTime.UtcNow.AddDays(-1),
                DateTo = DateTime.UtcNow.AddDays(5),
                StationId = weatherStationId
            };

            List<WeatherForecastResponseModel> responseModel = new()
            {
                new WeatherForecastResponseModel { Date = DateTime.UtcNow.AddDays(1), TemperatureC = 10, WeatherStationId = weatherStationId, WeatherStationName = weatherStationName},
                new WeatherForecastResponseModel { Date = DateTime.UtcNow.AddDays(2), TemperatureC = 20, WeatherStationId = weatherStationId, WeatherStationName = weatherStationName},
                new WeatherForecastResponseModel { Date = DateTime.UtcNow.AddDays(3), TemperatureC = 30, WeatherStationId = weatherStationId, WeatherStationName = weatherStationName },
                new WeatherForecastResponseModel { Date = DateTime.UtcNow.AddDays(4), TemperatureC = 40, WeatherStationId = weatherStationId, WeatherStationName = weatherStationName },
                new WeatherForecastResponseModel { Date = DateTime.UtcNow.AddDays(5), TemperatureC = 50, WeatherStationId = weatherStationId, WeatherStationName = weatherStationName }
            };

            weatherForecastServiceMock.Setup(s => s.SearchForecastsByStationId(requestModel)).Returns(responseModel);

            // Act
            var result = controller.GetForecastsByStationId(requestModel);
            var statusCode = ((JsonResult)result).StatusCode;
            var items = (List<WeatherForecastResponseModel>)((JsonResult)result).Value;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, statusCode);

            for (var i = 0; i < items.Count; i++)
            {
                Assert.Equal(DateTime.UtcNow.AddDays(i + 1).Date, items[i].Date.Date);
                Assert.Equal((i + 1) * 10, items[i].TemperatureC);
                Assert.Equal(weatherStationId, items[i].WeatherStationId);
                Assert.Equal(weatherStationName, items[i].WeatherStationName);
            }
        }
    }
}