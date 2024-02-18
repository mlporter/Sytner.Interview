namespace Synter.InterviewApi.Domain.RequestModels
{
    public class WeatherStation
    {
        public string StationCode { get; set; }

        public string StationName { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}