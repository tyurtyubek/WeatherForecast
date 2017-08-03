using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WeatherForecast.Context;
using WeatherForecast.Models;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace WeatherForecast.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CityController : ApiController
    {
        IRepository<SavedCity> _city;

        public CityController(IRepository<SavedCity> city)
        {
            _city = city;
        }

        //Get api/city/id

        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> GetCityAsync(int Id)
        {
            var cityById = await _city.GetByIdAsync(Id);

            return Ok(cityById);
        }

        //Get  api/city
        public IEnumerable<SavedCity> GetCitiesAsync()
        {
            return _city.Get();
        }

        // POST api/city
        [HttpPost]
        public IHttpActionResult PostCityAsync([FromBody]SavedCity city)
        {
            if (city == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                _city.Add(city);
                _city.Save();
                return new StatusCodeResult(HttpStatusCode.Created, this);
            }
            else
            {
                return new StatusCodeResult(HttpStatusCode.BadRequest, this);
            }
        }

        // PUT api/city
        [HttpPut]
        public IHttpActionResult PutAsync([FromBody]SavedCity city)
        {
            if (city == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                _city.EditCity(city);
                _city.Save();
                return new StatusCodeResult(HttpStatusCode.OK, this);
            }
            return BadRequest(ModelState);
        }

        // Delete api/city/24
        [HttpDelete]
        public async Task<IHttpActionResult> HttpDelete(int id)
        {
            if (id <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                await _city.DeleteAsync(id);
                _city.Save();
                return new StatusCodeResult(HttpStatusCode.OK, this);
            }
            return BadRequest(ModelState);
        }
    }
}
