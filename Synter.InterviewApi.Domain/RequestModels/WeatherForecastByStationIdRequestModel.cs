namespace Synter.InterviewApi.Domain.RequestModels
{
    public class WeatherForecastByStationIdRequestModel
    {
        public int StationId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}