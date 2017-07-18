using System.Collections.Generic;
using System.Web.Http;
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



    }
}
