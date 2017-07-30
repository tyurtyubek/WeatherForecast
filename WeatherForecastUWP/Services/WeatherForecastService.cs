using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastUWP.Models;

namespace WeatherForecastUWP.Services
{
    public class WeatherForecastService
    {
        string baseUrl = "http://localhost:45829";

        public async Task<RootObject> GetWeatherForecast(string city, int days)
        {
            using (var client = new HttpClient())
            {
                var _day = days;
                var _city = city;
                if (_city == null)  city = "Kiev";

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var json = await client.GetAsync($"api/Weather/{city}/{days}");
                var jsonstring = await json.Content.ReadAsStringAsync();
                try
                {
                    return JsonConvert.DeserializeObject<RootObject>(jsonstring);
                }
                catch(Exception ex)
                {
                    string exceptionGetforecastjson = "smth wrong" + ex.Message;
                    return null;
                }
            }
        }
    }
}
