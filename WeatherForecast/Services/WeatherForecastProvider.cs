using System;
using WeatherForecast.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public class WeatherForecastProvider : IWeatherForecastProvider
    {
        public async Task<RootObject> GetWeatherForecastJsonAsync(string cityoflist, int days, string cityOwn)
        {
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            string city = cityOwn != "" ? cityOwn : cityoflist;

            string openwmApiUrl = $"{baseUrl}q={city}&cnt={days}&APPID={apiKey}&units=metric";
            using( var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(openwmApiUrl);
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RootObject>(json);
                }
                catch (Exception ex)
                {
                    string exceptionGetforecastjson = "smth wrong" + ex.Message;
                    return null;
                }
            }
            
        }
    }
}