using Microsoft.AspNetCore.Mvc;
using Synter.InterviewApi.Application.Services.Interfaces;
using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Domain.RequestModels;
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

        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecastResponseModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55)
            });

            var serviceResult = ServiceResult<IEnumerable<WeatherForecastResponseModel>>.Success(data);

            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpPost(Name = "AddWeatherForecast")]
        public IActionResult Add(WeatherForecastRequestModel weatherForecast)
        {
            var data = _weatherForecastService.AddWeatherForecast(weatherForecast);
            WeatherForecastResponseModel mappedResponse = new()
            {
                Date = data.ForecastDate,
                TemperatureC = data.TemperatureC,
                WeatherStationId = data.WeatherStationId
            };
            var serviceResult = ServiceResult<WeatherForecastResponseModel>.Success(mappedResponse);
            return this.ServiceResultToActionResult(serviceResult);
        }
    }
}