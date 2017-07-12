using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class ConfigureCitiesController : Controller
    {
        IWeatherRepository<SavedCity> _savedCity;

        public ConfigureCitiesController(IWeatherRepository<SavedCity> savedCity)
        {
            _savedCity = savedCity;
        }


        // GET:  ConfigureCities/Configure
        [HttpGet]
        public ActionResult Configure()
        {
            IEnumerable<SavedCity> cities = _savedCity.GetCities();
            return View(cities);
        }
    }
}
