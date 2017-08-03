using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class ConfigureCitiesController : Controller
    {
        IRepository<SavedCity> _savedCity;

        public ConfigureCitiesController(IRepository<SavedCity> savedCity)
        {
            _savedCity = savedCity;
        }


        // GET:  ConfigureCities/Configure
        [HttpGet]
        public ActionResult Configure()
        {
            IEnumerable<SavedCity> cities = _savedCity.Get();
            return View(cities);
        }

        public ActionResult Delete(int? id)
        {
            _savedCity.DeleteAsync(id.Value);
            return RedirectToAction("Configure");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCityAsynk(int id, string cityName)
        {
            var cityUpdate = await _savedCity.GetByIdAsync(id);
            cityUpdate.CityName = cityName;
            _savedCity.Save();
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
            _savedCity.Add(newCity);
            _savedCity.Save();
            return RedirectToAction("Configure");
        }

    }
}
