using Microsoft.AspNetCore.Mvc;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.DataModels;
using Sytner.Utilities.AspNetCore.Extensions;
using Sytner.Utilities.ServiceResult;

namespace Sytner.InterviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherStationController : ControllerBase
    {
        private readonly ILogger<WeatherStationController> _logger;

        private readonly IWeatherStationService _weatherStationService;

        public WeatherStationController(ILogger<WeatherStationController> logger, IWeatherStationService weatherStationService)
        {
            _logger = logger;
            _weatherStationService = weatherStationService;
        }

        [HttpPost(Name = "AddWeatherStation")]
        public IActionResult Add(WeatherStationRequestModel weatherStation)
        {
            var data = _weatherStationService.AddWeatherStation(weatherStation);

            var serviceResult =
                ServiceResult<WeatherStation>.Success(data);
            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpPatch(Name = "UpdateWeatherStation")]
        public IActionResult Update(WeatherStationRequestModel weatherStation)
        {
            var data = _weatherStationService.Update(weatherStation);

            var serviceResult =
                ServiceResult<WeatherStation>.Success(data);
            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpGet("Get Weather Staion")]
        public IActionResult Get(int id)
        {
            var data = _weatherStationService.GetWeatherStation(id);
            var serviceResult =
                ServiceResult<WeatherStation>.Success(data);
            return this.ServiceResultToActionResult(serviceResult);
        }
    }
}