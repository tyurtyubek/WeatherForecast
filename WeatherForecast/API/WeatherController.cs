using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherForecast.Context;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {   
        private IWeatherForecastProvider _provider;
        private ICityLogRepository _citySearch;

        public WeatherController(IWeatherForecastProvider provider, ICityLogRepository citySearched)
        {
            _provider = provider;
            _citySearch = citySearched;
        }

        // Get /api/weather/Lviv/7
        [Route("api/Weather/{city}/{days}")]
        public async Task<IHttpActionResult> GetAsync(string city, int days)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (days < 0 || days > 17) { throw new HttpResponseException(HttpStatusCode.BadRequest); }
            var cityWeather = await _provider.GetWeatherForecastJsonAsync(city, days, "");
            if (cityWeather == null) return NotFound();
            try
            {
                _citySearch.AddLog(new CityLog() { CityName = city, RequestTime = DateTime.Now });
                _citySearch.Save();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok(cityWeather);
        }
    }
}
