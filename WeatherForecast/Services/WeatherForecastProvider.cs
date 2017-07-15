﻿using System;
using WeatherForecast.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Configuration;

namespace WeatherForecast.Services
{
    public class WeatherForecastProvider : IWeatherForecastProvider
    {
        public RootObject GetWeatherForecastJson(string cityoflist, int days, string cityOwn)
        {
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            string city = cityOwn != "" ? cityOwn : cityoflist;

            string openwmApiUrl = $"{baseUrl}q={city}&cnt={days}&APPID={apiKey}&units=metric";
            try
            {
                var client = new HttpClient();
                var json = client.GetStringAsync(openwmApiUrl).Result;
                return JsonConvert.DeserializeObject<RootObject>(json);
            }
            catch(Exception ex)
            {
                string exceptionGetforecastjson = "smth wrong" + ex.Message;
                return null;
            }
        }
    }
}