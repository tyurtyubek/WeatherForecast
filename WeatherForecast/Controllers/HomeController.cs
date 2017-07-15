using System;
using System.Collections.Generic;
using Ninject;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Services;
using WeatherForecast.Models;
using System.Net;
using WeatherForecast.Context;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        ICityLogRepository _cityLog;
        IWeatherForecastProvider _weather;
        IRepository<SavedCity> _savedCity;

        public HomeController(IWeatherForecastProvider weather,
                              IRepository<SavedCity> savedCity,
                              ICityLogRepository cityLog)
        {
            _weather = weather;
            _savedCity = savedCity;
            _cityLog = cityLog;
        }

        public ActionResult Index()
        {
            IEnumerable<SavedCity> cities = _savedCity.Get();
            return View(cities);
        }

        // GET: Home/GetForecast
        [HttpGet]
        public ActionResult GetForecast(string cityoflist, string cityOwn, string daysnumb)
        {
            var model = _weather.GetWeatherForecastJson(cityoflist, Convert.ToInt32(daysnumb), cityOwn);
            string city = cityOwn != "" ? cityOwn : cityoflist;
            _cityLog.AddLog(new CityLog
            {
                CityName = city,
                RequestTime = DateTime.Now
            });
            _cityLog.Save();
            return model == null ? View("Error") : View("GetForecast", model);
        }

        // GET: Home/CityLog
        [HttpGet]
        public ActionResult CityLog()
        {
            return View("CityLog",_cityLog.GetCitiesLog());
        }

        public ActionResult ClearHistory()
        {
            _cityLog.DeleteAll();
            return View("CityLog");
        }
        

    }
}