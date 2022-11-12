using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_Service.Models;

namespace WeatherApp_Service.Interfaces
{
    public interface IWeatherService
    {
        Task<List<DailyTemperatureModel>> GetDataFromWeatherApi(string cityName);
    }
}
