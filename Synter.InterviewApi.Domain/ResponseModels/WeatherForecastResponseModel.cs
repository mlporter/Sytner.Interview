using Synter.InterviewApi.Domain.Constants.Enums;

namespace Synter.InterviewApi.Domain.ResponseModels
{
    public class WeatherForecastResponseModel
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary => GetWeatherSummary(TemperatureC);

        public int WeatherStationId { get; set; }

        public string WeatherStationName => GetWeatherStationName(WeatherStationId);

        public string GetWeatherSummary(int tempC)
        {
            return tempC switch
            {
                <= 0 => WeatherSummary.Freezing.ToString(),
                <= 10 => WeatherSummary.Chilly.ToString(),
                <= 20 => WeatherSummary.Mild.ToString(),
                <= 30 => WeatherSummary.Warm.ToString(),
                <= 40 => WeatherSummary.Sweltering.ToString(),
                > 40 => WeatherSummary.Scorching.ToString()
            };
        }

        public string GetWeatherStationName(int stationId)
        {
            return "Corby"; // TODO Implement properly, getting from the database
        }

        
    }
}
