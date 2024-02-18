using Microsoft.AspNetCore.Mvc;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.RequestModels;
using Synter.InterviewApi.Domain.ResponseModels;
using Sytner.Utilities.AspNetCore.Extensions;
using Sytner.Utilities.ServiceResult;

namespace Sytner.InterviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastSearchController : ControllerBase
    {
        private readonly ILogger<WeatherForecastSearchController> _logger;

        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastSearchController(ILogger<WeatherForecastSearchController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetForecastsByStationId")]
        public IActionResult GetForecastsByStationId([FromQuery] WeatherForecastByStationIdRequestModel request)
        {
            var data = _weatherForecastService.SearchForecastsByStationId(request);
            var serviceResult = ServiceResult<IEnumerable<WeatherForecastResponseModel>>.Success(data);
            return this.ServiceResultToActionResult(serviceResult);
        }
    }
}
