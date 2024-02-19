namespace Synter.InterviewApi.Domain.RequestModels
{
    public class WeatherForecastUpdateRequestModel
    {
        public int Id { get; set; }

        public DateTime ForecastDate { get; set; }

        public int TemperatureC { get; set; }

        public int WeatherStationId { get; set; }
    }
}