using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WeatherForecast.Context;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.API
{
    public class WeatherController: ApiController
    {
        private IWeatherForecastProvider _provider;

        public WeatherController(IWeatherForecastProvider provider)
        {
            _provider = provider;
        }

        [Route("api/Weather/{city}/{days}")]
        public IHttpActionResult Get(string city, int days)
        {
            if (string.IsNullOrEmpty(city)) { throw new HttpResponseException(HttpStatusCode.BadRequest); }
            _provider.GetWeatherForecastJson(city, days, "");

            return new StatusCodeResult(HttpStatusCode.OK, this);
        }


    }
}
