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

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IActionResult Get()
        //{
        //    var data = Enumerable.Range(1, 5).Select(index => new WeatherForecastResponseModel
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55)
        //    });

        //    var serviceResult = ServiceResult<IEnumerable<WeatherForecastResponseModel>>.Success(data);

        //    return this.ServiceResultToActionResult(serviceResult);
        //}

        [HttpPost(Name = "AddWeatherForecast")]
        public IActionResult Add(WeatherForecastRequestModel weatherForecast)
        {
            var data = _weatherForecastService.AddWeatherForecast(weatherForecast);
            var serviceResult = ServiceResult<WeatherForecastResponseModel>.Success(data);
            return this.ServiceResultToActionResult(serviceResult);
        }

        [HttpGet(Name = "GetForecastsByStationId")]
        public IActionResult GetForecastsByStationId([FromQuery] WeatherForecastByStationIdRequestModel request)
        {
            var data = _weatherForecastService.SearchForecastsByStationId(request);
            var serviceResult = ServiceResult<IEnumerable<WeatherForecastResponseModel>>.Success(data);
            return this.ServiceResultToActionResult(serviceResult);
            throw new NotImplementedException();
        }
    }
}