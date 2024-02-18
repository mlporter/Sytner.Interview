using Microsoft.AspNetCore.Mvc;
using Synter.InterviewApi.Application;
using Synter.InterviewApi.Domain.RequestModels;

namespace Sytner.InterviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherStationController : ControllerBase
    {
        private readonly ILogger<WeatherStationController> _logger;

        public WeatherStationController(ILogger<WeatherStationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "AddWeatherStation")]
        public IActionResult Add(WeatherStation weatherStation)
        {
            throw new Exception();
        }
    }
}