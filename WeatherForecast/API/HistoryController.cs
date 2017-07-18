using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.API
{
    public class HistoryController : ApiController
    {
        private ICityLogRepository _citySearch;

        public HistoryController(ICityLogRepository citySearch)
        {
            _citySearch = citySearch;
        }

        //Get /api/history
        public IEnumerable<CityLog> Get()
        {
            return _citySearch.GetCitiesLog();
        }
        //Delete /api/history
        [HttpDelete]
        public StatusCodeResult DeleteHistory()
        {
            _citySearch.DeleteAll();
            _citySearch.Save();
            return new StatusCodeResult(HttpStatusCode.OK, this);
        }
    }
}
