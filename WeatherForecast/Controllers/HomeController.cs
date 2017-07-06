using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {

        private readonly List<string> cities = new List<string> { "Kiev", "Lviv", "Kharkiv", "Dnipropetrovsk", "Odessa" };
        public ActionResult Index()
        {
            var cityoflist = new List<SelectListItem>();
            foreach (var city in cities)
            {
                var selectListItem = new SelectListItem
                {
                    Value = city,
                    Text = city
                };
                cityoflist.Add(selectListItem);
            }
            ViewBag.Cities = cityoflist;
            var daysnumbSelect = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "weather for 1 day",
                    Value = "1",
                    Selected = true
                },
                new SelectListItem
                {
                    Text = "weather for 3 days",
                    Value = "3"
                },
                new SelectListItem
                {
                    Text = "weather for 7 days",
                    Value = "7",
                },
            };
            ViewBag.DaysNumb = daysnumbSelect;
            return View();
        }


        // GET: Home/GetForecast
        [HttpGet]
        public ActionResult GetForecast(string cityoflist, string cityOwn, string daysnumb)
        {
            WeatherForecastProvider weather = new WeatherForecastProvider();
            var model = weather.GetWeatherForecastJson(cityoflist, Convert.ToInt32(daysnumb), cityOwn);
            return View("GetForecast", model);
            return model == null ? View("Error") : View("GetForecast", model);
        }
    }
}