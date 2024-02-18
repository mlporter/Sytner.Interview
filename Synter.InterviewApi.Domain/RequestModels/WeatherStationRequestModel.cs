using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synter.InterviewApi.Domain.RequestModels
{
    public class WeatherStationRequestModel
    {
        public string StationCode { get; set; }

        public string StationName { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
