using Microsoft.AspNetCore.Mvc;
using Synter.InterviewApi.Domain.ResponseModels;
using Sytner.Utilities.AspNetCore.Extensions;
using Sytner.Utilities.ServiceResult;

namespace Sytner.InterviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55)
            });

            var serviceResult = ServiceResult<IEnumerable<WeatherForecast>>.Success(data);

            return this.ServiceResultToActionResult(serviceResult);
        }
    }
}