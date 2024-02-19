using Synter.InterviewApi.Domain.Constants.Enums;
using Synter.InterviewApi.Domain.ResponseModels;

namespace Synter.InterviewApi.UnitTests.DomainTests
{
    public class WeatherForecastResponseModelTests
    {
        [Theory]
        [InlineData(-5, WeatherSummary.Freezing)]
        [InlineData(5, WeatherSummary.Chilly)]
        [InlineData(15, WeatherSummary.Mild)]
        [InlineData(25, WeatherSummary.Warm)]
        [InlineData(35, WeatherSummary.Sweltering)]
        [InlineData(45, WeatherSummary.Scorching)]
        public void GetWeatherSummary_ReturnsCorrectSummary(int temperatureC, WeatherSummary expectedSummary)
        {
            // Arrange
            var weatherForecast = new WeatherForecastResponseModel
            {
                Date = DateTime.Today,
                TemperatureC = temperatureC
            };

            // Act
            var actualSummary = weatherForecast.GetWeatherSummary(temperatureC);

            // Assert
            Assert.Equal(expectedSummary.ToString(), actualSummary);
        }
    }
}