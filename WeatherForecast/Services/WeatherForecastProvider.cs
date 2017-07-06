using System;
using WeatherForecast.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;

namespace WeatherForecast.Services
{
    public class WeatherForecastProvider
    {
        private readonly string apiKey = "421cd20af77e3b17cb60061874c5c88f";

        public RootObject GetWeatherForecastJson(string cityoflist , int days, string cityOwn)
        {
            string city = "";
            if (cityOwn == "")
                city = cityoflist;
            else city = cityOwn;
            string openwmApiUrl =  $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&cnt={days}&APPID={apiKey}&units=metric";
            var client = new HttpClient();
            var json = client.GetStringAsync(openwmApiUrl).Result;
            return JsonConvert.DeserializeObject<RootObject>(json);
        }
    }
}