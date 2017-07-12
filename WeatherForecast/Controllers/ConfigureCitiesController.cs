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

        public ActionResult Delete(int? id)
        {
            _savedCity.DeleteCity(id.Value);
            return RedirectToAction("Configure");
        }

        [HttpPost]
        public ActionResult UpdateCity(int id, string cityName)
        {
            var cityUpdate = _savedCity.GetById(id);
            cityUpdate.CityName = cityName;
            _savedCity.SaveAll();
            return Json(new { Udpated = true });
        }

        public ActionResult AddCity()
        {
            return View("AddCity");
        }

        [HttpPost]
        public ActionResult AddCity(string cityName)
        {
            SavedCity newCity = new SavedCity() { CityName = cityName };
            _savedCity.AddCity(newCity);
            _savedCity.SaveAll();
            return RedirectToAction("Configure");
        }

    }
}
