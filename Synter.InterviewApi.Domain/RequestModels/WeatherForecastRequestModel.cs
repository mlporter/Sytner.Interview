namespace Synter.InterviewApi.Domain.RequestModels
{
    public class WeatherForecastRequestModel
    {
        public DateTime ForecastDate { get; set; }

        public int TemperatureC { get; set; }

        public int WeatherStationId { get; set; }
    }
}
