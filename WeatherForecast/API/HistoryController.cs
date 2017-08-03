using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
        public StatusCodeResult DeleteHistoryAsync()
        {
            _citySearch.DeleteAll();
            _citySearch.Save();
            return new StatusCodeResult(HttpStatusCode.OK, this);
        }
    }
}
