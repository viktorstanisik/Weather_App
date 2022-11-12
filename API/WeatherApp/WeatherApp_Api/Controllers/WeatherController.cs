using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using WeatherApp_Service.Interfaces;
using WeatherApp_Service.Models;
using WeatherApp_Shared;

namespace WeatherApp_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpPost("getweatherdata")]
        public async Task<IActionResult> GetWeatherData([FromBody] OpenWeatherApiRequestModel inputModel)
        {
            try
            {
                var data = await _weatherService.GetDataFromWeatherApi(inputModel.CityName.Trim());

                if (data.Count() == 0) throw new Exception(ErrorMessages.InvalidCityName);

                return Ok(data);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
