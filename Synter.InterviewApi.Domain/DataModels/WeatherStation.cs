using Sytner.Utilities.Domain;

namespace Synter.InterviewApi.Domain.DataModels
{
    public class WeatherStation : IBaseEntity<int>
    {
        public WeatherStation()
        {
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}