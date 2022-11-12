using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_Service.Interfaces;
using WeatherApp_Service.Models;
using WeatherApp_Shared.Helpers;

namespace WeatherApp_Service.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<List<DailyTemperatureModel>> GetDataFromWeatherApi(string cityName)
        {
            string json;

            using (var client = new HttpClient())
            {
                var url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&appid=b98ef33b84e97bd98bf4ca00c5905e03";

                var request = new RestRequest("/resource/", Method.Get);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("appid", "b98ef33b84e97bd98bf4ca00c5905e03");
                client.DefaultRequestHeaders.Add("q", cityName);
                //client.DefaultRequestHeaders.Add("cnt", "4");
                //client.DefaultRequestHeaders.Add("units", "metric");

                var endpoint = new Uri(url);

                var result = await client.GetAsync(endpoint);
                json = await result.Content.ReadAsStringAsync();
            }
            var response = JsonConvert.DeserializeObject<OpenWeatherApiResponseModel>(json);

            return ParseResponse(response);
        }

        private List<DailyTemperatureModel> ParseResponse(OpenWeatherApiResponseModel response)
        {
            List<DailyTemperatureModel> data = new();

            int num = 0;
            List<string> daysOfWeek = new();
            foreach (var item in response.list)
            {
                foreach (var value in item.weather)
                {
                    if (daysOfWeek.Contains(item.Dt_txt.Split(" ")[0])) continue;

                    DailyTemperatureModel responseToAngular = new()
                    {
                        Date = item.Dt,
                        Temperature = item.Main.Temp,
                        MaximumTemperature = item.Main.Temp_max,
                        MinimumTemperature = item.Main.Temp_min,
                        Humidity = item.Main.Humidity,
                        FeelsLike = item.Main.Feels_like,
                        Pressure = item.Main.Pressure,
                        WeatherCondition = value.Main,
                        WeatherConditionDescription = value.Description
                    };
                    num++;
                    if (num < 5) data.Add(responseToAngular);

                    daysOfWeek.Add(item.Dt_txt.Split(" ")[0]);
                }
            }

            return data;

        }
    }
}
