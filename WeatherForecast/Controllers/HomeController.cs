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
        IWeatherForecastProvider _weather;
        IWeatherRepository<SavedCity> _savedCity;

        public HomeController(IWeatherForecastProvider weather, IWeatherRepository<SavedCity> savedCity)
        {
            _weather = weather;
            _savedCity = savedCity;
        }

        public ActionResult Index()
        {
            IEnumerable<SavedCity> cities = _savedCity.GetCities();
            return View(cities);
        }

        // GET: Home/GetForecast
        [HttpGet]
        public ActionResult GetForecast(string cityoflist, string cityOwn, string daysnumb)
        {
            var model = _weather.GetWeatherForecastJson(cityoflist, Convert.ToInt32(daysnumb), cityOwn);
            return model == null ? View("Error") : View("GetForecast", model);
        }

        // GET: Home/
        [HttpGet]
        public ActionResult GetCities()
        {
            IEnumerable<SavedCity> cities =  _savedCity.GetCities();
            return View(cities);
        }
    }
}