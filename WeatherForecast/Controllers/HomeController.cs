using System;
using System.Collections.Generic;
using Ninject;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Services;
using System.Net;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        IWeatherForecastProvider _weather;

        public HomeController(IWeatherForecastProvider weather)
        {
            _weather = weather;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/GetForecast
        [HttpGet]
        public ActionResult GetForecast(string cityoflist, string cityOwn, string daysnumb)
        {
            var model = _weather.GetWeatherForecastJson(cityoflist, Convert.ToInt32(daysnumb), cityOwn);
            return model == null ? View("Error") : View("GetForecast", model);
        }
    }
}