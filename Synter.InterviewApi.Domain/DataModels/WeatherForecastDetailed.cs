using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sytner.Utilities.Domain;

namespace Synter.InterviewApi.Domain.DataModels
{
    public class WeatherForecastDetailed : BaseEntity<int>
    {
        public WeatherForecastDetailed()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime ForecastDate { get; set; }

        public int TemperatureC { get; set; }

        public int WeatherStationId { get; set; }

        public string WeatherStationName { get; set;}

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
